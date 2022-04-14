using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TokaDataAccess;
using TokaDataAccess.Repository.Implementaciones;
using TokaDataAccess.Repository.Interfaces;
using TokaDomain.AutoMapper;
using TokaService.Implementaciones;
using TokaService.Interfaces;
using TokaService.JWT.Implementaciones;
using TokaService.JWT.Interfaces;

namespace TokaAPI
{
    public class Startup
    {
        private readonly string cors = "cors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options=> {
                options.AddPolicy(name: cors,
                                  builder => 
                                      {
                                      builder.WithOrigins("*"); 
                                      });    
            });
            services.AddDbContext<TokaDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["JWT:Issuer"],
                       ValidAudience = Configuration["JWT:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(Configuration["JWT:ClaveSecreta"])
                       ),
                       ClockSkew = TimeSpan.Zero
                   };
               });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PersonaFisicaMap());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonaFisicaService, PersonaFisicaService>();
            services.AddScoped<IAutenticacionUsuarioService, AutenticacionUsuarioService>();
            services.AddScoped<IAutenticacionJWTService, AutenticacionJWTService>();


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
            app.UseCors(cors);
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
