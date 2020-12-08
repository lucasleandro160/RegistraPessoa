using RegistraPessoa.Dominio;
using RegistraPessoa.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistraPessoa.Dados.Entity.TypeConfiguration
{
    class PessoaTypeConfiguration : RegistraPessoaEntityAbstractConfig<Pessoa>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.IdPessoa)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdPessoa");

            Property(p => p.NomePessoa)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NomePessoa");

            Property(p => p.IdCategoria)
                .IsRequired()
                .HasColumnName("IdCategoria");
        }

        protected override void ConfigurarChaveEstrangeira()
        {
            HasRequired(p => p.Categoria)
                .WithMany(p => p.Pessoas)
                .HasForeignKey(fk => fk.IdCategoria);
        }

        protected override void ConfigurarChavePrimária()
        {
           HasKey(pk => pk.IdPessoa);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Pessoa");
        }
    }
}
