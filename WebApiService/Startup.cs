using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WebApiService;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApiService
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var configuration = new HttpConfiguration();

			configuration.MapHttpAttributeRoutes();
			app.UseWebApi(configuration);
		}
	}
}
