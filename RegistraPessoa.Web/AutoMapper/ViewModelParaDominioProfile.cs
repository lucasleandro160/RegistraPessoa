using AutoMapper;
using RegistraPessoa.Dominio;
using RegistraPessoa.Web.ViewModels.Categoria;
using RegistraPessoa.Web.ViewModels.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistraPessoa.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CategoriaViewModel, Categoria>();

            Mapper.CreateMap<PessoaViewModel, Pessoa>();

        }
    }
}