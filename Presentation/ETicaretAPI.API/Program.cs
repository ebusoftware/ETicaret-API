using ETicaretAPI.Application.Validators;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Infrastructure.Services.Storage.Azure;
using ETicaretAPI.Infrastructure.Services.Storage.Local;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceService();
builder.Services.AddInfrastructureServices();

builder.Services.AddStorage<AzureStorage>();
//builder.Services.AddStorage<LocalStorage>();



builder.Services.AddControllers(options => options.Filters.Add <ValidationFilter>())//kendi oluþturduðumuz filtreyi devreye sokuyoruz.
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator> //Veri kontrolü içi ekledik.
    ())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter=true); //mevcut yapýdaki validasyonu es geç.

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>

policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()

)) ;

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
app.UseAuthorization();

app.MapControllers();

app.Run();
