namespace NewsAggregatorBackend
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();

			WebApplication application = builder.Build();

			application.UseRouting();

			application.MapControllers();
			application.Run();
		}
	}
}
