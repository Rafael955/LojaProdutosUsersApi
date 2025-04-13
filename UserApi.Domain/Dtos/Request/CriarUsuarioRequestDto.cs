using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApi.Domain.Dtos.Request
{
    public class CriarUsuarioRequestDto
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o Nome do usuário.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de Email válido.")]
        [Required(ErrorMessage = "Por favor, informe o Email do usuário.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Por favor, informe a senha com letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a Senha do usuário.")]
        public string? Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem. Por favor, tente novamente.")]
        [Required(ErrorMessage = "Por favor, confirme a Senha do usuário.")]
        public string? ConfirmarSenha { get; set; }
    }
}
