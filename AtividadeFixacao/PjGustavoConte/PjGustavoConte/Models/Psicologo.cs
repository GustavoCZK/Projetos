using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PjGustavoConte.Models
{
    public class Psicologo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Data de nascimento requerida.")]
        [Display(Name = "Data de nascimento")]
        public DateTime BirthDate { get; set; }

        [ForeignKey("Psico")]
        public string PsicoId { get; set; }
        public AppPsico Psico { get; set; }
    }
}
