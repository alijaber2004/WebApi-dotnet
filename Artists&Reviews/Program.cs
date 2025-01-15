using Artists_Reviews.Data;
using Artists_Reviews.Interface;
using Artists_Reviews.Repository;
using Artists_Reviews.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer("Server=ALIJABER\\SQLEXPRESS;Database=ArtistDB;Trusted_Connection=True;TrustServerCertificate=True;");
});
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddHttpClient<ArtistService>();
builder.Services.AddScoped<SyncArtist>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// for email service
builder.Services.AddTransient<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
