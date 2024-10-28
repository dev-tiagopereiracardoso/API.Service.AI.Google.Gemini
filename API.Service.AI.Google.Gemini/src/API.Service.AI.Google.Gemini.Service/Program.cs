using API.Service.AI.Google.Gemini.Domain.Implementation.Interfaces;
using API.Service.AI.Google.Gemini.Domain.Implementation.Services;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
	c.EnableAnnotations();

	c.SwaggerDoc("v1", new OpenApiInfo { Title = "API - Service Google Gemini", Version = "v1" });

	c.TagActionsBy(api =>
	{
		if (api.GroupName != null)
		{
			return new[] { api.GroupName };
		}

		if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
		{
			return new[] { controllerActionDescriptor.ControllerName };
		}

		throw new InvalidOperationException("Unable to determine tag for endpoint.");
	});
	c.DocInclusionPredicate((name, api) => true);
});

builder.Services.AddScoped<IGoogleGeminiService, GoogleGeminiService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();