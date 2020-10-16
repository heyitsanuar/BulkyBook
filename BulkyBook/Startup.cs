using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using BulkyBook.DataAccess.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess.Repository;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using BulkyBook.Models;
using Microsoft.AspNet.OData.Extensions;

namespace BulkyBook
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private static IEdmModel GetEdmModel()
		{
			ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

			builder.EntitySet<Song>("Songs");

			return builder.GetEdmModel();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOData();
			services.AddMvc(option => option.EnableEndpointRouting = false);
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request piphttps://www.officedepot.com.mx/officedepot/en/Categor%C3%ADa/Todas/c/0-0-0-0?q=pizarron%3Arelevance&page=1eline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(builder =>
			{
				builder.WithOrigins("*");
				builder.AllowAnyMethod();
				builder.AllowAnyHeader();
			});

			app.UseMvc(routeBuilder =>
			{
				routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
				routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
			});

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
