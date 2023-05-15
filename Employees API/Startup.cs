using Employees_API.BusinessLogicLayer;
using Employees_API.DataAccessLayer;

namespace Employees_API
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
            services.AddHttpClient<EmployeeDataAccessLayer>(client =>
            {
                client.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1/");
            });

            services.AddScoped<EmployeeDataAccessLayer>();
            services.AddScoped<EmployeeBusinessLogicLayer>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
