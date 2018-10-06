using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Servicos.Models
{
    public class ClienteCadastroModel
    {
        [MinLength(6, ErrorMessage ="Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage ="Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage ="Informe o campo Cliente.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage ="Informe um endereço de email válido.")]
        [Required(ErrorMessage ="Informe o email do cliente.")]
        public string Email { get; set; }
    }
}