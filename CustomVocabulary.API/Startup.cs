using CustomVocabulary.Core;
using CustomVocabulary.Core.Services;
using CustomVocabulary.Data;
using CustomVocabulary.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CustomVocabulary.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<CustomVocabularyDbContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("CustomVocabularyConnection"), x => x.MigrationsAssembly("CustomVocabulary.Data")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IVocabularyService, VocabularyService>();
            services.AddTransient<IWordService, WordService>();


            //Handling a never-ending loop caused by the interrelation between Vocabulary and Word models
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
