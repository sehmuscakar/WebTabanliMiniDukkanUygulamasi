using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniDukan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukan
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MiniDukkanContext>();//(opts => opts.UseSqlServer(Configuration["ConnectionStrings:MiniDukkanConnection"]));// týrnak içindeki appsettings teki baðlantý ismi
                                                                                                                                         //UseSqlServer da sql serverin kullandýðý ve baðlantý dizesinin  Configuration nesnesi ile okundu
            services.AddScoped<IDukkanRepository, EFDukkanRepository>();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //burdakiler Midelwarelerdir corenin kalbidir aslýnda diyebiliriz
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();// bu uygulamada meydana gelen istisnalarý görüntüler
           
            
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//bu wwwroot klasöürünün içindekileri kullanýmýna imkan saðlar

            app.UseRouting();//bu istek hattýna baðlanýyor

            app.UseStatusCodePages();//bunu ekledik http yanýtlarýna basit mesajlar eklemek için yapýlýr

            app.UseAuthorization();

            app.UseEndpoints(endpoints => // buda istek hatýna baðlanýyor
            {
                endpoints.MapControllerRoute("sayfalama", "Urunler/Sayfa{urunSayfa}", // bunu url kýsmýda sayfa=1 olmasý sayfa1 olsun direk için yaptýk
                    new { Controller = "Home", action = "Index" });
                endpoints.MapDefaultControllerRoute();
                
            });

            HamVeri.VeriDoldur(app);//buraya ekledik
        }
    }
}
