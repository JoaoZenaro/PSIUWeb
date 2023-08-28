using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIUWeb.Models
{
    public enum Ethnicity { 
        Asiático, 
        Branco, 
        Índio, 
        Negro,
        Pardo,
        Outros
    }

    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Informe a Data de nascimento.")]
        [Display(Name = "Data de nascimento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Informe o Peso.")]
        [Display(Name = "Peso")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Informe a Altura.")]
        [Display(Name = "Altura")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "Informe a Etnia.")]
        [Display(Name = "Etnia")]
        public Ethnicity Ethnicity { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
    }
}