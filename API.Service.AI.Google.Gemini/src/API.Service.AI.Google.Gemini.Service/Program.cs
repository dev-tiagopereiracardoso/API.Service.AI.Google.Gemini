using API.Service.AI.Google.Gemini.Domain.Implementation.Interfaces;
using API.Service.AI.Google.Gemini.Domain.Implementation.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGoogleGeminiService, GoogleGeminiService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();