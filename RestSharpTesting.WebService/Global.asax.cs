using System;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace RestSharpTesting.WebService
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Forces WebAPI to return JSON (http://stackoverflow.com/questions/12629144/how-to-force-asp-net-web-api-to-always-return-json)
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
