using RegistraPessoa.Web.Filtros;
using System.Web;
using System.Web.Mvc;

namespace RegistraPessoa.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogActionFilter());
        }
    }
}
