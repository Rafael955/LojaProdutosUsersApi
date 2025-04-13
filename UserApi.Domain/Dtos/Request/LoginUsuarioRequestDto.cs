using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Domain.Dtos.Request
{
    public class LoginUsuarioRequestDto
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de Email válido.")]
        [Required(ErrorMessage = "Por favor, informe o Email do usuário.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe uma senha com no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a Senha do usuário.")]
        public string? Senha { get; set; }
    }
}
