using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identityServer.db;
using identityServer.@is;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace identityServer
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
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("database_name"));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();
            services.AddTransient<IAuthRepository, AuthRepository>();
            //services.AddIdentityServer()
            //        .AddDeveloperSigningCredential()
            //        .AddInMemoryApiResources(ResourceManager.Apis)
            //        .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
            //        .AddInMemoryClients(ClientManager.Clients);

            var builder = services.AddIdentityServer(options =>
                                    {
                                        options.EmitStaticAudienceClaim = false;
                                        options.IssuerUri = "something";
                                    })
                                    .AddDeveloperSigningCredential()
                                    .AddInMemoryIdentityResources(ResourceManager.Ids)
                                    .AddInMemoryApiScopes(ResourceManager.ApiScopes)
                                    .AddInMemoryApiResources(ResourceManager.ApiResources)
                                    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                                    .AddInMemoryClients(ClientManager.Clients);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
