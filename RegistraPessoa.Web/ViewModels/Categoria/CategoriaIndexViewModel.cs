using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistraPessoa.Web.ViewModels.Categoria
{
    public class CategoriaIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ocupação Profissional")]
        public string Nome { get; set; }

        [Display(Name = "Sexo")]
        public int Sexo { get; set; }
    }
}