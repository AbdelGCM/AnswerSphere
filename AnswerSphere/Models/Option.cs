
namespace AnswerSphere.Models;
public class Option
{
    public int OptionId { get; set; }
    public string OptionLibelle { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public List<Reponse> Reponses { get; set; } = new List<Reponse>();
}