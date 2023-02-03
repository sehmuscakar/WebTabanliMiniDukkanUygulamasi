using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukan.Models
{
    public static class HamVeri
    {
        public static void VeriDoldur(IApplicationBuilder app)
        {
            MiniDukkanContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<MiniDukkanContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Urunler.Any())
            {
                context.Urunler.AddRange(new Urun
                {
                    UrunAd = "çıncırak",
                    Açıklama = "bebek cıncırak boncukları",
                    Kategori = "bebek oyuncakları",
                    fiyat = 15
                },


                  new Urun
                 {
                     UrunAd = "oyun halısı",
                     Açıklama = "cıncıraklı oyun halısı",
                     Kategori = "bebek oyuncakları",
                     fiyat = 150
                 },
                 new Urun
                  {
                      UrunAd = "barbie bebek",
                      Açıklama = "barbie elbiseli bebek ",
                      Kategori = "kız oyuncakları",
                      fiyat = 60
                  },

                  new Urun
                  {
                      UrunAd = "Mutfak seti",
                      Açıklama = "barbie elbiseli bebk",
                      Kategori = "kız oyuncakları",
                      fiyat = 120
                  },

                   new Urun
                   {
                       UrunAd = "barbie evi",
                       Açıklama = "portatif barbie evi",
                       Kategori = "kız oyuncakları",
                       fiyat = 15
                   },

                   new Urun
                    {
                        UrunAd = "oyuncakmermili tabanca",
                        Açıklama = "plastik mermi atan tabanca",
                        Kategori = "erkek oyuncakları",
                        fiyat = 30
                    },

                    new Urun
                     {
                         UrunAd = "futbol topu",
                         Açıklama = "mikasa futbol topu",
                         Kategori = "erkek oyuncakları",
                         fiyat = 100
                     },

                      new Urun
                      {
                          UrunAd = "Pubg oyun seti",
                          Açıklama = "pubg saldırı seti",
                          Kategori = "erkek oyuncakları",
                          fiyat = 200
                      },

                      new Urun
                       {
                           UrunAd = "akülü jip",
                           Açıklama = "mikasa volvo jip",
                           Kategori = "genel oyuncakları",
                           fiyat = 2500
                       }

                );
                context.SaveChanges();
            }
        
        }
    }
}
