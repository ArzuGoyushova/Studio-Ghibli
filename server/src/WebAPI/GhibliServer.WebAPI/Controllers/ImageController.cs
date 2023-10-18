using GhibliServer.Domain.Entities;
using GhibliServer.Persistence.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;

        public ImageController(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        [HttpDelete("images/{imageType}/{imageName}")]
        public IActionResult DeleteImage(string imageType, string imageName)
        {
            try
            {
                string imagesFolderPath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/", "images", imageType);
                string filePath = Path.Combine(imagesFolderPath, imageName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);

                    if (imageType == "products")
                    {
                        var productImages = _appDbContext.Pictures.Where(p => p.ProductId != null).ToList();
                        var image = productImages.FirstOrDefault(i => i.ImageUrl == imageName);
                        if (image != null)
                        {
                            _appDbContext.Pictures.Remove(image);
                            _appDbContext.SaveChanges();
                        }
                    }
                    else if (imageType == "movies")
                    {
                        var movieImages = _appDbContext.Pictures.Where(p => p.MovieId != null).ToList();
                        var image = movieImages.FirstOrDefault(i => i.ImageUrl == imageName);
                        if (image != null)
                        {
                            _appDbContext.Pictures.Remove(image);
                            _appDbContext.SaveChanges();
                        }
                    }
                    else if (imageType == "users")
                    {
                        var user = _appDbContext.Users.FirstOrDefault(u => u.ImageUrl == imageName);
                        if (user != null)
                        {
                            user.ImageUrl = null;
                            _appDbContext.SaveChanges();
                        }
                    }
                    else if (imageType == "event")
                    {
                        var user = _appDbContext.Events.FirstOrDefault(u => u.ImageUrl == imageName);
                        if (user != null)
                        {
                            user.ImageUrl = null;
                            _appDbContext.SaveChanges();
                        }
                    }
                }

                return Ok(new { message = "Image deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to delete image. Please try again later." });
            }
        }
    }
}
