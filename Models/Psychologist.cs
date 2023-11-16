using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace PSIUWeb.Models
{
    // Talvez utilizar nome 'Therapist'?
    public class Psychologist
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Informe a CRP.")]
        [Display(Name = "CRP")]
        public string? CRP { get; set; }

        [Required(ErrorMessage = "Informe a Liberação.")]
        [Display(Name = "Liberação")]
        public bool hasClearance { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }

        [Required(ErrorMessage = "Informe o Endereço.")]
        [Display(Name = "Endereço(s)")]
        public List<Address>? Addresses { get; set; }
    }
}