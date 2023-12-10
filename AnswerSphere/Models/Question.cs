namespace Answersphere.Models;
public class Question
{
    public int QuestionId { get; set; }
    public string QuestionLibelle { get; set; }
    public List<Option> Options { get; set; } = new List<Option>();
}