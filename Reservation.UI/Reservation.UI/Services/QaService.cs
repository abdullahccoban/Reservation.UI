using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Qa;
using Reservation.UI.Models.DTOs.Response.Qa;

namespace Reservation.UI.Services;

public class QaService : IQaService
{
    private readonly IQaRepository _qaRepository;

    public QaService(IQaRepository qaRepository)
    {
        _qaRepository = qaRepository;
    }
    
    public async Task<List<QaResponseDto>?> GetAnsweredQuestions(int hotelId)
        => await _qaRepository.GetAnsweredQuestions(hotelId);

    public async Task AskQuestion(AskQuestionRequestDto request)
    {
        var domain = new QaDomain(request.HotelId, request.Question);
        await _qaRepository.AskQuestion(domain);
    }

    public async Task<List<QaResponseDto>?> GetAllQuestions(int hotelId)
        => await _qaRepository.GetAllQuestions(hotelId);

    public async Task AnswerQuestion(AnswerRequestDto request)
    {
        var question = await _qaRepository.GetQuestion(request.Id);
        
        if (question == null) 
            throw new ArgumentNullException();
        
        var domain = new QaDomain(question.HotelId, question.Question, question.QuestionDate, id: question.Id);
        domain.AnswerQuestion(request.Answer);
        
        await _qaRepository.Answer(domain);
    }
}