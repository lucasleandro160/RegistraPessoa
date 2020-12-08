using RegistraPessoa.Dados.Entity.Context;
using RegistraPessoa.Dominio;
using RegistraPessoa.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RegistraPessoa.Repositorios.Entity
{
    public class PessoasRepositorio : RepositorioGenericoEntity<Pessoa, int>
    {
        public PessoasRepositorio(PessoaDbContext contexto)
            :base(contexto)
        {
        }

        public override List<Pessoa> Selecionar()
        {
            return _contexto.Set<Pessoa>().Include(p => p.Categoria).ToList();
        }

        public override Pessoa SelecionarPorId(int id)
        {
            return _contexto.Set<Pessoa>().Include(p => p.Categoria)
                .SingleOrDefault(f => f.IdPessoa == id);
        }
    }
}
