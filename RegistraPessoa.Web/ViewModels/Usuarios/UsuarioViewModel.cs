using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistraPessoa.Web.ViewModels.Usuarios
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O E-mail é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}