using Reservation.UI.Models.DTOs.Request.Qa;
using Reservation.UI.Models.DTOs.Response.Qa;

namespace Reservation.UI.Interfaces.Services;

public interface IQaService
{
    Task<List<QaResponseDto>?> GetAnsweredQuestions(int hotelId);
    Task AskQuestion(AskQuestionRequestDto request);
    Task<List<QaResponseDto>?> GetAllQuestions(int hotelId);
    Task AnswerQuestion(AnswerRequestDto request);
}