using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace WebApiService
{
	class Program
	{
		static void Main(string[] args)
		{
			var baseAddress = "http://localhost:8000";
			using (WebApp.Start<Startup>(url: baseAddress))
			{
				Console.WriteLine("Press Enter key to stop the server...");
				Console.ReadLine();
			}
		}
	}
}
