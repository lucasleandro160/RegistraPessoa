using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistraPessoa.Web.ViewModels.Categoria
{
    public class CategoriaViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Ocupação Profissional da categoria é obrigatória!")]
        [MaxLength(100, ErrorMessage = "A Ocupação Profissional deve ter no máximo 100 caracteres!")]
        [Display(Name = "Ocupação Profissional")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sexo das pessoas dessa Ocupação Profissional é obrigatório!")]
        [Display(Name = "Sexo das Pessoas")]
        public int Sexo { get; set; }

    }
}