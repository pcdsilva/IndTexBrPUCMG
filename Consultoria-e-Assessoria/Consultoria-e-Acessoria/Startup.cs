using Consultoria_e_Assessoria.Token;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Consultoria_e_Assessoria.Startup))]

namespace Consultoria_e_Assessoria
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableSwagger(c => {
                c.SingleApiVersion("v1", "Consultoria_e_Assessoria");
                c.IncludeXmlComments(AppDomain.CurrentDomain.BaseDirectory + @"\bin\Consultoria_e_Assessoria.xml");
            });

            app.UseCors(CorsOptions.AllowAll);

            AtivandoAcessTokens(app);

            app.UseWebApi(config);
        }

        private void AtivandoAcessTokens(IAppBuilder app)
        {
            //var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            //{
            //    AllowInsecureHttp = true,
            //    TokenEndpointPath = new PathString("/token"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
            //    Provider = new ProviderDeTokensDeAcesso()
            //};

            //app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}