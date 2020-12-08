using RegistraPessoa.Dominio;
using RegistraPessoa.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistraPessoa.Dados.Entity.TypeConfiguration
{
    class CategoriaTypeConfiguration : RegistraPessoaEntityAbstractConfig<Categoria>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.OcupacaoProfissional)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("OcupacaoProfissional");

            Property(p => p.Sexo)
                .IsRequired()
                .HasColumnName("Sexo");

        }

        protected override void ConfigurarChaveEstrangeira()
        {
        }

        protected override void ConfigurarChavePrimária()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Categoria");
        }
    }
}
