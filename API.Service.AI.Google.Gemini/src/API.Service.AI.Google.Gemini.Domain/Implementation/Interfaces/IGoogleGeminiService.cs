using API.Service.AI.Google.Gemini.Models.Input;
using API.Service.AI.Google.Gemini.Models.Output;

namespace API.Service.AI.Google.Gemini.Domain.Implementation.Interfaces
{
	public interface IGoogleGeminiService
	{
		Task<GoogleGeminiOutput?> Question(GoogleGeminiInput Question);
	}
}