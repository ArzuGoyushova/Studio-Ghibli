using GhibliServer.Application;
using GhibliServer.Persistence;
using GhibliServer.WebAPI;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://arzugoyushova.github.io")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});


builder.Services.PersistenceServiceRegister(config);
builder.Services.ApplicationServiceRegister();
builder.Services.ApiServiceRegister(config);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();




app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
