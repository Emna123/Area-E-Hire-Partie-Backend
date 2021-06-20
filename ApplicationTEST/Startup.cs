using ApplicationTEST.Models;
using EmailService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Text;

namespace ApplicationTEST
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
            //services.AddDbContext<TodoContext>(opt =>opt.UseInMemoryDatabase("maa"));
            var emailConfig = Configuration
           .GetSection("EmailConfiguration")
            .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            //For entity framework
          
            services.AddDbContext<TodoContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

               services.AddIdentity<User,IdentityRole>()
                   .AddDefaultTokenProviders()
                 //  .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Candidat, IdentityRole>>()
                   //.AddDefaultUI()
                   .AddRoles<IdentityRole>()
                   .AddEntityFrameworkStores<TodoContext>();

          /*  services.AddIdentity<Candidat, IdentityRole>()
              .AddRoles<IdentityRole>()
              // .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Responsable_RH, IdentityRole>>()
              .AddEntityFrameworkStores<TodoContext>()
                              //  .AddDefaultUI()
                              .AddDefaultTokenProviders();


            services.AddIdentityCore<Responsable_RH>()
                //  .AddRoles<Resp>()
                // .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Responsable_RH, IdentityRole>>()
                .AddEntityFrameworkStores<TodoContext>()
                .AddDefaultTokenProviders();*/

                //  .AddDefaultUI()
                // .AddTokenProvider<DataProtectorTokenProvider<Responsable_RH>>(TokenOptions.DefaultProvider);

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            {
                opt.Name = "Default";
                opt.TokenLifespan = TimeSpan.FromHours(1);
            });

           

            //Adding authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))


                };
            });

            services.AddCors();

            services.AddControllers()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot/uploads")),
                RequestPath = "/Files",

            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot/images")),
                RequestPath = "/Photos",

            });
            /*var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = "http://localhost:5000/",
                IssuerSigningKey = new X509SecurityKey(new X509Certificate2(certLocation)),
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions()
            {
                Audience = "http://localhost:5001/",
                AutomaticAuthenticate = true,
                TokenValidationParameters = tokenValidationParameters
            });*/

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}