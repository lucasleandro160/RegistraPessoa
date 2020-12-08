using RegistraPessoa.Dados.Entity.TypeConfiguration;
using RegistraPessoa.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistraPessoa.Dados.Entity.Context
{
    public class PessoaDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        public PessoaDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaTypeConfiguration());
            modelBuilder.Configurations.Add(new PessoaTypeConfiguration());
        }
    }
}
