using Microsoft.Extensions.Options;

using RedSocial_API.Models;
using RedSocial_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RedSocialSettings>(builder.Configuration.GetSection(nameof(RedSocialSettings)));
builder.Services.AddSingleton<IRedSocialSettings>(d => d.GetRequiredService<IOptions<RedSocialSettings>>().Value);

builder.Services.AddSingleton<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
