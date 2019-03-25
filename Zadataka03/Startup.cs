using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Zadataka03.Controllers;
using Zadataka03.Filters;
using Zadataka03.Services;
using Zadataka03.Models;
using Zadataka03.Repositories;
using Zadataka03.UnitOfWork;

namespace Zadataka03
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
            //services.AddDbContext<ZadatakContext>(opt =>
            //    opt.UseInMemoryDatabase("ZadatakList"));
            services.AddAutoMapper();

            //registracija konteksta
            services.AddDbContext<ZadatakContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ZadatakDB"]));

            //registracija filtera
            //services.AddFiltersService();

            services.AddMvc(option =>
            {
                option.Filters.Add(typeof(UnitOfWorkFilter));
                option.Filters.Add(typeof(CustomExceptionService));
                option.Filters.Add(typeof(ResultExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //DI - gdje god dodamo interfejs u konstuktoru ce se kreirati instanca repozitorijuma
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOsoba, ROsoba>();
            services.AddScoped<IUredjaj, RUredjaj>();
            services.AddScoped<IKancelarija, RKancelarija>();
            services.AddScoped<IUredjajUzetVracen, RUredjajUzetVracen>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "05.02.2019",
                    Title = "Zadatak za vježbu I",
                    Description = "Osobe/Uredjaji/Kancelarije",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            //Ne rade mi servisi preko atributa, provjeri sta se desava.
            //servisi dodati preko atributa
            //services.AddDIService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMapper autoMapper)
        {
            //autoMapper.ConfigurationProvider.AssertConfigurationIsValid();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Primjeri za middleweare
            //1:
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Zdravo svima, ");
            //    await next();
            //    await context.Response.WriteAsync("Bane!");
            //});
            //app.Run(async (context) => { await context.Response.WriteAsync("moje ime je "); });

            //2:
            //app.Use(async (context, next) =>
            //{
                
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    var stoprica = new Stopwatch();
            //    stoprica.Stop();
            //    var izmjereno = stoprica.ElapsedMilliseconds;
            //    await context.Response.WriteAsync($"Proslo je {izmjereno} ms.");
            //});

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
