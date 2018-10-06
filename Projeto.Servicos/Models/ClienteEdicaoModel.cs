using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Servicos.Models
{
    public class ClienteEdicaoModel
    {
        [Required(ErrorMessage ="Informe o id do cliente.")]
        public int IdCliente { get; set; }

        [MinLength(6, ErrorMessage ="Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage ="Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage ="Informe o nome do cliente.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage ="Informe um endereço de email válido.")]
        [Required(ErrorMessage ="Informe o email do cliente.")]
        public string Email { get; set; }
    }
}