using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PSIUWeb.Models
{
    public enum Gender { Feminino, Masculino, Outros }

    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "Informe o Nome.")]
        [Display(Name = "Nome completo")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Informe a Data de nascimento.")]
        [Display(Name = "Data de nascimento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Informe o Sexo/Gênero.")]
        [Display(Name = "Sexo/Gênero")]
        public Gender Gender { get; set; }
        
        public DateTime CreationDate { get; set; }
    }
}