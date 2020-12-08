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
    public class CategoriasRepositorio : RepositorioGenericoEntity<Categoria, int>
    {
        public CategoriasRepositorio(PessoaDbContext contexto) 
            :base(contexto)
        {
        }

       public override List<Categoria> Selecionar()
       {
            return _contexto.Set<Categoria>().Include(p => p.Pessoas).ToList();
       }

        public override Categoria SelecionarPorId(int id)
        {
            return _contexto.Set<Categoria>().Include(p => p.Pessoas)
                .SingleOrDefault(a => a.Id == id);
        }
    }
}
