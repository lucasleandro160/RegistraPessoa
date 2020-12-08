using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistraPessoa.Generica.Entity
{
    // Automatiza o processo de criação da estrutura do banco criando uma espécie de Template que varia de acordo com a estrutura de cada entidade.
    public abstract class RegistraPessoaEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        // Define que TEntidade é uma classe.
        where TEntidade : class 
    {
        public RegistraPessoaEntityAbstractConfig()
        {
            ConfigurarNomeTabela();
            ConfigurarCamposTabela();
            ConfigurarChavePrimária();
            ConfigurarChaveEstrangeira();
        }

        protected abstract void ConfigurarChaveEstrangeira();

        protected abstract void ConfigurarChavePrimária();

        protected abstract void ConfigurarCamposTabela();

        protected abstract void ConfigurarNomeTabela();
    }
}
