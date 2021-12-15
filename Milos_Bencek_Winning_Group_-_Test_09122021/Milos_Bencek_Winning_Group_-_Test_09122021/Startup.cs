using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Milos_Bencek_Winning_Group___Test_09122021.DAL;
using Milos_Bencek_Winning_Group___Test_09122021.Interfaces;
using Milos_Bencek_Winning_Group___Test_09122021.Services;

namespace Milos_Bencek_Winning_Group___Test_09122021
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TestDBDatabaseSettings>(Configuration.GetSection(nameof(TestDBDatabaseSettings)));
            services.AddSingleton<ITestDBDatabaseSettings>( sp => sp.GetRequiredService<IOptions<TestDBDatabaseSettings>>().Value );
            services.AddSingleton<IProductService, ProductService>();
            services.AddMediatR(typeof(Startup));

            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing())
                .AddFluentValidation(fv => 
                {
                    fv.DisableDataAnnotationsValidation = true;
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
