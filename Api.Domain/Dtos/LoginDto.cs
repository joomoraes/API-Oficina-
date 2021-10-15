using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é campo obrigatório para Login")]
        [EmailAddress(ErrorMessage = "Email em formato invalido")]
        [StringLength(100, ErrorMessage = "Email deve conter no mínimo {1} caracteres")]
        public string Email { get; set; }
    }
}
