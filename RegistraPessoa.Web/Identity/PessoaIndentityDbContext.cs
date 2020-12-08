using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistraPessoa.Web.Identity
{
    public class PessoaIndentityDbContext : IdentityDbContext<IdentityUser>
    {
      public PessoaIndentityDbContext()
            : base("PessoaDbContext")
        {

        }

    }
}