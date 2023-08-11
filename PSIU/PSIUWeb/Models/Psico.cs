using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PSIUWeb.Models
{
    public class Psico
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome Requerido.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CPR Requerido.")]
        [Display(Name = "CRP")]
        public string CRP { get; set; }
        [Required(ErrorMessage = "Release Requerido.")]
        [Display(Name = "Released")]
        public bool Released { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        //navigation propert
    }
}
