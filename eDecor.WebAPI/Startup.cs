using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eDecor.Model;
using eDecor.Model.Requests;
using eDecor.WebAPI.Controllers;
using eDecor.WebAPI.Database;
using eDecor.WebAPI.Filters;
using eDecor.WebAPI.Security;
using eDecor.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace eDecor.WebAPI
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
            //Filtr za exceptione
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Swagger", "");
            });

            //Autentikacija
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


            services.AddControllers();

            //Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic" }
                        }, new string[] { } }
                });
            });


            //konfigurisemo AutoMapper 
            services.AddAutoMapper(typeof(Startup));

            //Implementacija interfejsa
            //Artikli
            services.AddScoped<IBaseCRUDService<Model.Artikli, ArtikliSearchRequest, ArtikliUpsertRequest, ArtikliUpsertRequest>, ArtikliService>();
            //Drzave
            services.AddScoped<IBaseCRUDService<Model.Drzave, object, DrzaveUpsertRequest, DrzaveUpsertRequest>, BaseCRUDService<Model.Drzave, object, Database.Drzave,DrzaveUpsertRequest, DrzaveUpsertRequest>>();
            //Gradovi
            services.AddScoped<IGradoviService, GradoviService>();
            //Kategorije
            services.AddScoped<IBaseCRUDService<Model.Kategorije, object, KategorijeUpsertRequest, KategorijeUpsertRequest>, BaseCRUDService<Model.Kategorije, object, Database.Kategorije, KategorijeUpsertRequest, KategorijeUpsertRequest>>();
            //Klijenti
            services.AddScoped<IKlijentiService, KlijentiService>();
            //Korisnici
            services.AddScoped<IKorisniciService, KorisniciService>();
            //Notifikacije
            services.AddScoped<IBaseCRUDService<Model.Notifikacije, NotifikacijeSearchRequest, NotifikacijeUpsertRequest, NotifikacijeUpsertRequest>,NotifikacijeService>();
            //Ocjene
            services.AddScoped<IBaseCRUDService<Model.Ocjene, OcjeneSearchRequest, OcjeneUpsertRequest, OcjeneUpsertRequest>, OcjeneService>();
            //Podkategorije
            services.AddScoped<IBaseCRUDService<Model.Podkategorije, PodkategorijeSearchRequest, PodkategorijeUpsertRequest, PodkategorijeUpsertRequest>, PodkategorijeService>();
            //Popusti
            services.AddScoped<IBaseCRUDService<Model.Popusti, object, PopustiUpsertRequest, PopustiUpsertRequest>, BaseCRUDService<Model.Popusti, object, Database.Popusti, PopustiUpsertRequest, PopustiUpsertRequest>>();
            //Pretplate
            services.AddScoped<IBaseCRUDService<Model.Pretplate, PretplateSearchRequest, PretplateUpsertRequest, PretplateUpsertRequest>, PretplateService>();
            //Rezervacije
            services.AddScoped<IBaseCRUDService<Model.Rezervacije, RezervacijeSearchRequest, RezervacijeUpsertRequest, RezervacijeUpsertRequest>, RezervacijeService>();
            //Uloge
            services.AddScoped<IBaseService<Model.Uloge, object>, BaseService<Model.Uloge, object, Database.Uloge>>();
            //Login
            services.AddScoped<ILoginService, LoginService>();
            //Sistem preporuke
            services.AddScoped<IPreporukeService, PreporukeService>();

            //ConnectionString unutar appsettings.json
            services.AddDbContext<eDecorContext>(options => options.UseSqlServer(Configuration.GetConnectionString("eDecor")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            
            //podesimo middlewere za auth
            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
