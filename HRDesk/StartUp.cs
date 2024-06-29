using HRDesk.Authentication;
using HRDesk.BL.IServices;
using HRDesk.BL.Services;
using HRDesk.DL.Context;
using HRDesk.DL.IRepo;
using HRDesk.DL.Repo;
using HRDesk.Models.Mapping.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace HRDesk
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DbfirstApproachContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("UserProfile")));
            services.AddScoped<ILoginServices, LoginServices>();
            services.AddScoped<IEmployeeservices, EmployeeServices>();
            services.AddScoped<ILoginDL, LoginDL>();
            services.AddScoped<IEmployeeDL, EmployeeDL>();
            services.AddEndpointsApiExplorer();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.RegisterMapper();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnetclaimauthorization", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please Insert Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTTokenGeneratorModel:SecurityKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization();

            var jwtToken = Configuration.GetSection("JWTTokenGeneratorModel");
            services.Configure<JWTTokenGeneratorModel>(jwtToken);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnetclaimauthorization v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors(builder => builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
