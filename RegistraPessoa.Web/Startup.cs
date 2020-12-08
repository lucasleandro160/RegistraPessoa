using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(RegistraPessoa.Web.Startup))]

namespace RegistraPessoa.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IAppBuilder appBuilder = app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Usuario/Login")
            });
        }
    }
}
