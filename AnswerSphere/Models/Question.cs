using System.ComponentModel.DataAnnotations;

namespace AnswerSphere.Models;
public class Question
{
    public int QuestionId { get; set; }

    [Required(ErrorMessage = "Le libellé de la question est requis.")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Le libellé de la question doit avoir entre 5 et 255 caractères.")]
    [Display(Name = "Libellé de la question")]
    public string? QuestionLibelle { get; set; }

    public ICollection<Option>? Options { get; set; }
}

