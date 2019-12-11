using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieShop.Data;
using MovieShop.Data.Repository;
using MovieShop.Data.RepositoryInterfaces;
using MovieShop.Services;
using MovieShop.Services.ServiceInterfaces;

namespace MovieShopAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Sets the policy name to "_myAllowSpecificOrigins". The policy name is arbitrary.
        private readonly string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MovieShopDbContext>(options =>
                                                          options.UseSqlServer(Configuration.GetConnectionString("MovieShopDbConnection")));

            // The AddCors method call adds CORS services to the app's service container. The
            // AddCors method takes lambda expression takes a CorsPolicyBuilder object
            services.AddCors(options =>
                {
                    options.AddPolicy(_myAllowSpecificOrigins,
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                        }
                        );
                }
            );

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICryptoService, CryptoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            // UseCors extension method, which enables CORS in Configure(IApplicationBuilder
            // app, IHostingEnvironment env) method
            app.UseCors(_myAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
