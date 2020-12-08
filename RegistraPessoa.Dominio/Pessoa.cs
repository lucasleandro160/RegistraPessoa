using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistraPessoa.Dominio
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int IdCategoria { get; set; }
    }
}
