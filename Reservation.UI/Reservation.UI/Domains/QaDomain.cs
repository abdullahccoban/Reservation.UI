namespace Reservation.UI.Domains;

public class QaDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string Question { get; private set; }
    public DateTime QuestionDate { get; private set; }
    public string Answer { get; private set; }
    public DateTime AnswerDate { get; private set; }

    public QaDomain(int hotelId, string question, DateTime? questionDate = null, int id = 0)
    {
        if (string.IsNullOrEmpty(question)) throw new ArgumentNullException();
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        
        HotelId = hotelId;
        Question = question;
        QuestionDate = questionDate.HasValue ? questionDate.Value : DateTime.UtcNow;

        if (id > 0) Id = id;
    }

    public void AnswerQuestion(string answer)
    {
        if (string.IsNullOrEmpty(answer)) throw new ArgumentNullException();
        Answer = answer;
        AnswerDate = DateTime.UtcNow;
    }
}