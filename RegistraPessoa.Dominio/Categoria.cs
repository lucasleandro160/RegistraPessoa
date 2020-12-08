using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistraPessoa.Dominio
{
    public class Categoria
    {
        public int Id { get; set;  }
        public string OcupacaoProfissional { get; set; }
        public char Sexo { get; set; }
        public virtual List<Pessoa> Pessoas { get; set; }
    }
}
