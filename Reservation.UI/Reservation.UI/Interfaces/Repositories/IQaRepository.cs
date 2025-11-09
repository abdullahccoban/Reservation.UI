using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Response.Qa;

namespace Reservation.UI.Interfaces.Repositories;

public interface IQaRepository
{
    Task<List<QaResponseDto>?> GetAnsweredQuestions(int hotelId);
    Task AskQuestion(QaDomain model);
    Task<List<QaResponseDto>?> GetAllQuestions(int hotelId);
    Task<QaResponseDto?> GetQuestion(int id);
    Task Answer(QaDomain model);
}