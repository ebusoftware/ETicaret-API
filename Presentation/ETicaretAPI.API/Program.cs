using ETicaretAPI.Application;
using ETicaretAPI.Application.Validators;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Infrastructure.Services.Storage.Azure;
using ETicaretAPI.Infrastructure.Services.Storage.Local;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceService();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddStorage<AzureStorage>();
//builder.Services.AddStorage<LocalStorage>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, //Olusturulacak token degerini kimlerin/hangi originlerin/sitelerin kullanıcı belirledigimiz degerdir. -> www.bilmemne.com
            ValidateIssuer = true, //Olusturulacak token deðerini kimin dagıttını ifade edecegimiz alandır. -> www.myapi.com
            ValidateLifetime = true, //Olusturulan token degerinin süresini kontrol edecek olan dogrulamadır.
            ValidateIssuerSigningKey = true, //Üretilecek token degerinin uygulamamıza ait bir deger oldugunu ifade eden suciry key verisinin dogrulanmasıdır.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false
        };
    });



builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())//kendi oluþturduðumuz filtreyi devreye sokuyoruz.
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator> //Veri kontrolü içi ekledik.
    ())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true); //mevcut yapýdaki validasyonu es geç.

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>

policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()

));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();