using System.ComponentModel.DataAnnotations;

namespace AnswerSphere.Models;
 
public class Reponse
{
    public int ReponseId { get; set; }

    [Display(Name = "Nom du répondant")]
    [Required(ErrorMessage = "Le Nom du répondant est requis.")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Le Nom du répondant doit avoir entre 5 et 255 caractères.")]
    public string? RepondantNom { get; set; }

    public int OptionId { get; set; }

    public Option? Option { get; set; }
}
