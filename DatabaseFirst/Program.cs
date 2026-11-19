using DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connectionString = builder.Configuration.GetConnectionString("OrderDbConnection");
			builder.Services.AddDbContext<OrderDbContext>(options =>
			options.UseSqlServer(connectionString));

			// Add services to the container.

			builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler =
			System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

			builder.Services.AddOpenApi();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
