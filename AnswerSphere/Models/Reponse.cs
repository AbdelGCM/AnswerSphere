namespace Answersphere.Models;

public class Reponse
{
    public int ReponseId { get; set; }
    public int OptionId { get; set; } 
    public Option Option { get; set; } 
    public int RepondantId { get; set; }
    public string RepondantNom { get; set; }
}