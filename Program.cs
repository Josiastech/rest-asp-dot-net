using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BlogPostApi
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				BuildWebHost(args).Run();
			}
		}

		public static IWebHost BuildWebHost(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.UseUrls("http://*:5000")
				.UseStartup<Startup>()
				.Build();
		}
	}
}