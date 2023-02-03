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
            services.AddDbContext<MiniDukkanContext>();//(opts => opts.UseSqlServer(Configuration["ConnectionStrings:MiniDukkanConnection"]));// t�rnak i�indeki appsettings teki ba�lant� ismi
                                                                                                                                         //UseSqlServer da sql serverin kulland��� ve ba�lant� dizesinin  Configuration nesnesi ile okundu
            services.AddScoped<IDukkanRepository, EFDukkanRepository>();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //burdakiler Midelwarelerdir corenin kalbidir asl�nda diyebiliriz
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();// bu uygulamada meydana gelen istisnalar� g�r�nt�ler
           
            
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//bu wwwroot klas��r�n�n i�indekileri kullan�m�na imkan sa�lar

            app.UseRouting();//bu istek hatt�na ba�lan�yor

            app.UseStatusCodePages();//bunu ekledik http yan�tlar�na basit mesajlar eklemek i�in yap�l�r

            app.UseAuthorization();

            app.UseEndpoints(endpoints => // buda istek hat�na ba�lan�yor
            {
                endpoints.MapControllerRoute("sayfalama", "Urunler/Sayfa{urunSayfa}", // bunu url k�sm�da sayfa=1 olmas� sayfa1 olsun direk i�in yapt�k
                    new { Controller = "Home", action = "Index" });
                endpoints.MapDefaultControllerRoute();
                
            });

            HamVeri.VeriDoldur(app);//buraya ekledik
        }
    }
}
