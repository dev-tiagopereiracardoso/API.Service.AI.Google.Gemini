using API.Service.AI.Google.Gemini.Domain.Implementation.Interfaces;
using API.Service.AI.Google.Gemini.Models.Input;
using API.Service.AI.Google.Gemini.Models.Output;
using GeminiChat.DotNet;
using Microsoft.Extensions.Configuration;

namespace API.Service.AI.Google.Gemini.Domain.Implementation.Services
{
	public class GoogleGeminiService : IGoogleGeminiService
	{
		private string _apiKeyGoogleGemini { set; get; }

		public GoogleGeminiService(
				IConfiguration configuration
			)
		{
			_apiKeyGoogleGemini = configuration["GoogleGeminiApiKey"]!;
		}

		public async Task<GoogleGeminiOutput?> Question(GoogleGeminiInput Question)
		{
			var service = new GeminiService(_apiKeyGoogleGemini);

			service.AppendMessage(Question.Question);

			var answer = await service.GetResponseAsync();

			return new GoogleGeminiOutput
			{
				Answer = answer
			};
		}
	}
}