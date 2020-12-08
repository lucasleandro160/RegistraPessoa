using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistraPessoa.Web.ViewModels.Pessoa
{
    public class PessoaIndexViewModel
    {
        public int IdPessoa { get; set; }

        [Display(Name = "Nome do Pessoa")]
        public string NomePessoa { get; set; }

        [Display(Name = "Nome do Álbum")]
        public string NomeCategoria { get; set; }
    }
}