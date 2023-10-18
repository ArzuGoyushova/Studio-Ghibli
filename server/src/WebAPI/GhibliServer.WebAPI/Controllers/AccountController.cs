using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Features.Commands.AccountCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GhibliServer.WebAPI.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Vonage;
using Vonage.Verify;
using GhibliServer.Application.Features.Queries.AccountQueries;
using Microsoft.AspNetCore.Authorization;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _cache;
        private readonly IFileService _fileService;
        private readonly IVonageService _vonageService;
        private readonly VonageClient _vonageClient;

        public AccountController(IMediator mediator, IEmailService emailService, IMemoryCache cache, IFileService fileService, IVonageService vonageService, VonageClient vonageClient, IConfiguration config = null)
        {
            _mediator = mediator;
            _emailService = emailService;
            _cache = cache;
            _config = config;
            _fileService = fileService;
            _vonageService = vonageService;
            _vonageClient = vonageClient;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var command = new RegisterUserCommand { RegisterDto = registerDto };
            var registerResult = await _mediator.Send(command);

            if (!registerResult.Success)
            {
                var response = new
                {
                    success = false,
                    message = registerResult.Message,
                    error = registerResult.Errors
                };
                return BadRequest(response);
            }
            else
            {
                var response = new
                {
                    success = true,
                    message = "User registered successfully",
                    value = registerResult.Value
                };

                _cache.Set("RegisteredUserEmail", registerDto.Email, TimeSpan.FromMinutes(10));
                _cache.Set("RegisteredUserPhoneNumber", registerDto.PhoneNumber, TimeSpan.FromMinutes(10));

                string otp = GenerateOTP();
                _cache.Set(registerDto.Email, otp, TimeSpan.FromMinutes(10));

                string body = string.Empty;
                string path = "wwwroot/templates/verify.html";
                string subject = "Verify Email";

                body = _fileService.ReadFile(path, body);
                body = body.Replace("{{otp}}", otp);
                body = body.Replace("{{name}}", registerDto.FullName);

                _emailService.Send(registerDto.Email, subject, body);
                await _vonageService.SendVerificationCode(registerDto.PhoneNumber);


                return Ok(response);
            }
        }


        [HttpPost("resend-otp")]
        public async Task<IActionResult> ResendOTP()
        {
            var userEmail = _cache.Get<string>("RegisteredUserEmail");

            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest(new { success = false, message = "User information not found." });
            }

            string otp = GenerateOTP();
            _cache.Set(userEmail, otp, TimeSpan.FromMinutes(10));

            string body = string.Empty;
            string path = "wwwroot/templates/verify.html";
            string subject = "Resend OTP Code";

            body = _fileService.ReadFile(path, body);
            body = body.Replace("{{otp}}", otp);
            string fullName = "Visitor";
            body = body.Replace("{{name}}", fullName);

            _emailService.Send(userEmail, subject, body);

            return Ok(new { success = true, message = "OTP code has been resent successfully." });
        }


        public static string GenerateOTP()
        {
            Random random = new Random();
            int otpNumber = random.Next(100000, 999999);
            return otpNumber.ToString();
        }
        private string GetSavedOtp(string userEmail)
        {
            if (_cache.TryGetValue(userEmail, out string otp))
            {
                return otp;
            }

            return null;
        }

        [Route("verify")]
        [HttpPost]
        public async Task<IActionResult> VerifyAccount(VerifyAccountDto verifyDto)
        {
            string savedOtp = GetSavedOtp(verifyDto.Email);

            if (savedOtp == null || savedOtp != verifyDto.Otp)
            {
                return BadRequest(new { success = false, message = "Invalid OTP" });
            }

            var markVerifiedCommand = new MarkAccountAsVerifiedCommand { UserId = verifyDto.UserId };
            var result = await _mediator.Send(markVerifiedCommand);

            if (result.Success)
            {
                return Ok(new { success = true, message = "Account verified successfully" });
            }
            else
            {
                return BadRequest(new { success = false, message = "Account verification failed" });
            }
        }

        [Route("verify-sms")]
        [HttpPost]
        public async Task<IActionResult> VerifySMS(VerifyPhoneNumberDto verifyDto)
        {
            try
            {
                string phoneNumber = verifyDto.PhoneNumber;
                string userEnteredCode = verifyDto.Otp;
                string requestId = _vonageService.GetRequestId(verifyDto.PhoneNumber);

                var checkResponse = await _vonageClient.VerifyClient.VerifyCheckAsync(new VerifyCheckRequest
                {
                    RequestId = requestId,
                    Code = userEnteredCode
                });

                if (checkResponse.Status == "0")
                {
                    var markVerifiedCommand = new MarkPhoneNumberVerifiedCommand { UserId = verifyDto.UserId };
                    var result = await _mediator.Send(markVerifiedCommand);

                    if (result.Success)
                    {
                        return Ok(new { success = true, message = "Phone Number verified successfully" });
                    }
                    else
                    {
                        return BadRequest(new { success = false, message = "Phone Number verification failed" });
                    }
                }
                else
                {
                    return BadRequest(new { success = false, message = "Invalid OTP" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occurred during SMS verification" });
            }
        }


        [HttpPost("google-login")]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleLogin(string googleCredential)
        {
            var googleToken = googleCredential;
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(googleToken);

            var email = jwtSecurityToken.Claims.First(claim => claim.Type == "email").Value;
            
            var loginEmail = new GoogleLoginCommand { GoogleCredentialEmail = email };

            var loginResult = await _mediator.Send(loginEmail);

            if (!loginResult.Success)
            {
                var response = new
                {
                    success = false,
                    message = loginResult.Message,
                    errors = loginResult.Errors
                };
                return BadRequest(response);
            }

            var user = loginResult.Value.User;
            var userRoles = loginResult.Value.UserRoles;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            var claimList = new List<Claim>();
            claimList.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claimList.Add(new Claim("username", user.UserName));
            claimList.Add(new Claim("role", userRoles[0]));
            claimList.Add(new Claim("imageUrl", user.ImageUrl));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddMinutes(40),
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token), message = "Successful" });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var loginCommand = new LoginCommand { LoginDto = loginDto };

            var loginResult = await _mediator.Send(loginCommand);

            if (!loginResult.Success)
            {
                var response = new
                {
                    success = false,
                    message = loginResult.Message,
                    errors = loginResult.Errors
                };
                return BadRequest(response);
            }

            var user = loginResult.Value.User;
            var userRoles = loginResult.Value.UserRoles;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            var claimList = new List<Claim>();
            claimList.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claimList.Add(new Claim("username", user.UserName));
            claimList.Add(new Claim("role", userRoles[0]));
            claimList.Add(new Claim("imageUrl", user.ImageUrl ?? ""));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddMinutes(40),
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token), message = "Successful" });
        }


        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var passEmail = new ResetPasswordCommand { Email = email };

            var resetResult = await _mediator.Send(passEmail);

            if (resetResult==null)
            {
                var response = new
                {
                    success = false
                };
                return BadRequest(response);
            }

            string body = string.Empty;
            string path = "wwwroot/templates/resetPassword.html";
            string subject = "Reset Password";

            body = _fileService.ReadFile(path, body);
            string resetPasswordUrl = "https://arzugoyushova.github.io/StudioGhibli/account/new-password";
            var tokenQueryParam = $"?token={resetResult.Token}&email={resetResult.Email}";

            var callbackUrl = $"{resetPasswordUrl}{tokenQueryParam}";
            body = body.Replace("{{callbackUrl}}", callbackUrl);

            _emailService.Send(resetResult.Email, subject, body);

            return Ok();
        }

        [HttpPost("update-password")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand command)
        {
            var updateResult = await _mediator.Send(command);

            if (!updateResult.Success)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Password update failed. Please try again later.",
                    errors = updateResult.Errors 
                });
            }

            return Ok(new
            {
                success = true,
                message = updateResult.Message 
            });
        }



        [Authorize]
        [Route("user-data")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            var query = new GetUserQuery();
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }

            return Ok(response.Value);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateUserProfileCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }

    }


}
