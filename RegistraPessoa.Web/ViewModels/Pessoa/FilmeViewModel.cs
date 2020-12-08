using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistraPessoa.Web.ViewModels.Pessoa
{
    public class PessoaViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório!")]
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "O Nome do Pessoa é obrigatório!")]
        [Display(Name = "Nome do Pessoa")]
        public string NomePessoa { get; set; }

        [Required(ErrorMessage = "Selecione um álbum!")]
        [Display(Name = "Nome do Álbum")]
        public int IdCategoria { get; set; }
    }
}