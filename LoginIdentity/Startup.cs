using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(LoginIdentity.Startup))]

namespace LoginIdentity
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {

                AuthenticationType = "ApplicationCookie",
                LoginPath= new PathString("/autenticacao/login")

            });

            //AuthenticationType — Este é uma string que identifica o cookie.Isto é necessário, 
            //uma vez que pode ter várias instâncias do middleware Cookie. Por exemplo, 
            //quando se utiliza servidores de autenticação externos(OAuth / OpenID) o mesmo middleware cookie é usado 
            //para passar reivindicações do provedor externo. Se tivéssemos puxado no pacote Microsoft.AspNet.Identity 
            //NuGet poderíamos simplesmente usar o DefaultAuthenticationTypes.ApplicationCookie constante que tem o mesmo valor — “ApplicationCookie”.
            //LoginPath — O caminho para o qual o agente de usuário(navegador) deve ser redirecionado para quando seu aplicativo retorna uma resposta não autorizada(401). Este deve corresponder ao seu controlador “login”. Neste caso, eu tenho uma AuthContoller com uma ação de login.

        }
    }
}
