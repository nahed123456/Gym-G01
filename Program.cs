using GymG01.Contexts;
using GymManagmemnt.BLL.Services.Classes;
using GymManagmemnt.BLL.Services.Interface;
using GymManagment.DAL;
using GymManagment.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gym_G01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IPlanRepository, PlanRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddScoped<IGenericRepository, GenericRepository>();

            // EF Core Will Create Object From DbContext AUTOMATIC When We Request It From The Contai
            builder.Services.AddDbContext<GymDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
