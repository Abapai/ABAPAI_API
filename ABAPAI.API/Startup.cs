using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Handlers;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Infra.Contexts;
using ABAPAI.Infra.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


namespace ABAPAI.API
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
            services.AddControllers();
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SQL_SERVER")));
            services.AddScoped<StaffHandler, StaffHandler>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IFileUpload>(x => new FileUpload(Configuration.GetConnectionString("NAME_CONTAINER"), Configuration.GetConnectionString("KEY_AZURE_BLOB")));

            services.AddAuthentication()
                .AddJwtBearer(Roles.STAFF.ToString(), x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e")),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            string SchemeSTAFF_JWT = $"JWT_{Roles.STAFF}";
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(Roles.STAFF.ToString())
                    .Build();

                options.AddPolicy(SchemeSTAFF_JWT, new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(Roles.STAFF.ToString())
                    .Build());
            });

            services.AddSwaggerGen(c => //adicionando o Swagger
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Abapai API", Version = "v1" });
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

            app.UseSwagger(); //Utilizando o Swagger
            app.UseSwaggerUI(c => //utilizando o Swagger UI(Ferramenta Visual) 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Abapai API");
            });

            app.UseRouting();

            app.UseCors(x =>
            {
                x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
