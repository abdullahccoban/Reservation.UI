using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Qa;

namespace Reservation.UI.Controllers;

[Route("qa")]
public class QaController : Controller
{
    private readonly IQaService _qaService;

    public QaController(IQaService qaService)
    {
        _qaService = qaService;
    }
    
    [HttpGet("getAnsweredQuestions")]
    public async Task<IActionResult> GetAnsweredQuestions(int hotelId)
    {
        var qas = await _qaService.GetAnsweredQuestions(hotelId);
        return Ok(qas);
    }

    [HttpPost("ask")]
    public async Task<IActionResult> AskQuestion([FromBody] AskQuestionRequestDto request)
    {
        await _qaService.AskQuestion(request);
        return Ok();
    }

    [HttpPost("answer")]
    public async Task<IActionResult> AnswerQuestion([FromBody] AnswerRequestDto request)
    {
        await _qaService.AnswerQuestion(request);
        return Ok();
    }
}