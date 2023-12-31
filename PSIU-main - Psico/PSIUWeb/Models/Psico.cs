using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIUWeb.Models
{    
    
    public class Psico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Data de nascimento requerida.")]
        [Display(Name = "Data de nascimento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Tempo trabalhado como Psicólogo requerido.")]
        [Display(Name = "Tempo como Psicólogo")]
        public string? TimeWork { get; set; }

        [Required(ErrorMessage = "Formação Academica requerida.")]
        [Display(Name = "Formação Acadêmica")]
        public string? Graduation { get; set; }

        [Required(ErrorMessage = "Raça requerida.")]
        [Display(Name = "Raça")]
        public Race Race { get; set; }

        [ForeignKey("Psicol")]
        public string? PsicoId { get; set; }
        public AppUser? User { get; set; }
    }
}