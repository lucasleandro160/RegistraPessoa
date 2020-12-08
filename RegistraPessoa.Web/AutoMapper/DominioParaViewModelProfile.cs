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
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Categoria, CategoriaIndexViewModel>()
                .ForMember(p => p.Nome, opt =>
                {
                    opt.MapFrom(src =>
                        string.Format("{M} {F}", src.OcupacaoProfissional, src.Sexo.ToString())
                    );
                });
            Mapper.CreateMap<Categoria, CategoriaViewModel>();

            Mapper.CreateMap<Pessoa, PessoaIndexViewModel>()
                .ForMember(p => p.NomeCategoria, opt =>
                {
                    opt.MapFrom(src =>
                        src.Categoria.OcupacaoProfissional
                    );
                });
            Mapper.CreateMap<Pessoa, PessoaViewModel>();
        }
    }
}