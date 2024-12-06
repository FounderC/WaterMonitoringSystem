using Microsoft.EntityFrameworkCore;
using WaterMonitoringSystemTest.DAL;
using WaterMonitoringSystemTest.DAL.UnitOfWork;

namespace WaterMonitoringSystemTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WaterMonitoringContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 26)))
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine, LogLevel.Information)
            );

            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            // авторизація через cookie 'auth_token'
            app.Use(async (context, next) =>
            {
                var token = context.Request.Cookies["auth_token"];
                if (!string.IsNullOrEmpty(token) && token == "valid_token")
                {
                    // Імітуємо авторизованого користувача
                    context.User = new System.Security.Claims.ClaimsPrincipal(
                        new System.Security.Claims.ClaimsIdentity(new[]
                        {
                            new System.Security.Claims.Claim("name", "Admin User"),
                            new System.Security.Claims.Claim("role", "Admin")
                        }, "FakeScheme"));
                }

                await next.Invoke();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
