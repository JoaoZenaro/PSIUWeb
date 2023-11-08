using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIUWeb.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Psychologist")]
        public int PsychologistId { get; set; }
        public Psychologist? Psychologist { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro.")]
        [Display(Name = "Logradouro")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "Informe o Número.")]
        [Display(Name = "Número")]
        public string? Number { get; set; }

        [Display(Name = "Complemento")]
        public string? Complement { get; set; }

        [Required(ErrorMessage = "Informe a Cidade.")]
        [Display(Name = "Cidade")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Informe o Estado.")]
        [Display(Name = "Estado")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Informe o CEP.")]
        [Display(Name = "CEP")]
        public string? ZipCode { get; set; }

        [Display(Name = "Endereço Principal")]
        public bool IsMainAddress { get; set; }
    }
}