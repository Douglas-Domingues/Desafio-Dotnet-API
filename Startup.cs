using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySql.EntityFrameworkCore.Extensions;
using TrilhaApiDesafio.Context;
using MySql.EntityFrameworkCore;
using MySql.Data;
using MySql.EntityFrameworkCore.Diagnostics;

namespace StartUp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("ConexaoPadrao");

            services.AddDbContext<OrganizadorContext>(options =>
                options.UseMySQL(connectionString));

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Add any middleware your application needs here...

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
