using API.Service.AI.Google.Gemini.Domain.Implementation.Interfaces;
using API.Service.AI.Google.Gemini.Models.Input;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Service.AI.Google.Gemini.Service.Controllers
{
	[Route("v1/google-gemini")]
	[ApiController]
	[ApiExplorerSettings(GroupName = "gemini")]
	public class GoogleGeminiController : ControllerBase
	{
		private readonly IGoogleGeminiService _googleGeminiService;

		public GoogleGeminiController(
				IGoogleGeminiService googleGeminiService
			)
		{
			_googleGeminiService = googleGeminiService;
		}

		[HttpPost("question")]
		[SwaggerOperation(Summary = "")]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<object>))]
		[SwaggerResponse(StatusCodes.Status400BadRequest)]
		[SwaggerResponse(StatusCodes.Status401Unauthorized)]
		[SwaggerResponse(StatusCodes.Status417ExpectationFailed)]
		public IActionResult Question(GoogleGeminiInput Obj)
		{
			var Data = _googleGeminiService.Question(Obj).Result;

			return Ok(Data!.Answer);
		}
	}
}
