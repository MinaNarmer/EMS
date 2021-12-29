using AutoMapper;
using EFGHermes.BL.Helpers.MapperConfig;
using EFGHermes.BL.IServices;
using EFGHermes.BL.Services;
using EFGHermes.DAL.IRepositories;
using EFGHermes.DAL.Repositories;
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.DAL.IRepository;
using EFGHermes.Data.DAL.Persistance;
using EFGHermes.Data.DAL.Repository;
using EFGHermes.Data.Models;
using EFGHermes.Data.Models.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFGHermes.Web
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
            services.AddDbContext<HermesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GeneralProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            #region Resolve Repositories
            services.AddControllersWithViews();
            services.AddScoped<IHotelRepository,HotelRepository>();
            services.AddScoped<IInvestorRepository, InvestorRepository>();
            services.AddScoped<IInvestorSectorRepository, InvestorSectorRepository>();
            services.AddScoped<IPresenterRepository, PresenterRepository>();
            services.AddScoped<IPresenterSectorRepository, PresenterSectorRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRoomRepository,RoomRepository>();
            services.AddScoped<IRoomSlotRepository,RoomSlotRepository>();
            services.AddScoped<ISectorRepository,SectorRepository>();
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Resolve Services    
            services.AddScoped<IHotelServices, HotelServices>();
            services.AddScoped<IInvestorService, InvestorService>();
            services.AddScoped<IPresenterService, PresenterService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReportService, ReportService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HermesContext _context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            SeedData.SeedSectors(_context);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
