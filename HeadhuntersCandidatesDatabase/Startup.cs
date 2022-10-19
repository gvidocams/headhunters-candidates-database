using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using HeadhuntersCandidatesDatabase.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HeadhuntersCandidatesDatabase
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HeadhuntersCandidatesDatabase", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("HeadhuntersCandidates");

            services.AddDbContext<HeadhuntersCandidatesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IHeadHuntersCandidatesDbContext, HeadhuntersCandidatesDbContext>();
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IEntityService<Company>, EntityService<Company>>();
            services.AddScoped<IEntityService<Candidate>, EntityService<Candidate>>();
            services.AddScoped<IEntityService<Position>, EntityService<Position>>();
            services.AddScoped<IEntityService<CandidatePositions>, EntityService<CandidatePositions>>();
            services.AddScoped<IEntityService<CompanyPositions>, EntityService<CompanyPositions>>();
            services.AddScoped<ICandidatePositionService, CandidatePositionService>();
            services.AddScoped<ICompanyPositionService, CompanyPositionService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<ISkillService, SkillService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HeadhuntersCandidatesDatabase v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
