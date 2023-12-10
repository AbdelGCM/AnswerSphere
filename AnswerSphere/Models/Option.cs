using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnswerSphere.Models;
public class Option
{
    public int OptionId { get; set; }

    [Display(Name = "Le libellé de l'option")]
    [Required(ErrorMessage = "Le libellé de l'option est requis.")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Le libellé de l'option doit avoir entre 5 et 255 caractères.")]
    public string? OptionLibelle { get; set; }

    [ForeignKey("Question")]
    public int QuestionId { get; set; }

    public Question? Question { get; set; }

    public ICollection<Reponse>? Reponses { get; set; }
}

