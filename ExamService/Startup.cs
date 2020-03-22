using ExamService.Models;
using ExamService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace ExamService
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
            services.Configure<ExamCURDDatabaseSettings>(
            Configuration.GetSection(nameof(ExamCURDDatabaseSettings)));

            services.AddSingleton<IExamCURDDatabaseSettings>(sp =>
              sp.GetRequiredService<IOptions<ExamCURDDatabaseSettings>>().Value);

            services.AddSingleton<ExamRepository>();

            services.AddCors(options =>
            {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader().Build());
            });

            services.AddControllers();
            services.AddSwaggerGen(C =>
            {
                C.SwaggerDoc("ExamServiceOpenApi", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ExamService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();



            //app.UseAuthorization();
 
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/ExamServiceOpenApi/swagger.json", "ExamService");
            });
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
