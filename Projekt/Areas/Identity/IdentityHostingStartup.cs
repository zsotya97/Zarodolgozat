using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projekt.Areas.Identity.Data;
using Projekt.Data;

[assembly: HostingStartup(typeof(Projekt.Areas.Identity.IdentityHostingStartup))]
namespace Projekt.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            ///SQlite ot használ a program
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProjektContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("ProjektContextConnection")));
                //Ha véletlen áttérne a program MYSQL re:

                /*services.AddDbContext<ProjektContext>(options => options.UseMySql(
                        "server=localhost;user=root;password=;database=novenyekproba",
                        new MySqlServerVersion(new Version(8, 0, 21))));*/

                services.AddDefaultIdentity<ProjektUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddEntityFrameworkStores<ProjektContext>();
            });
        }
    }
}