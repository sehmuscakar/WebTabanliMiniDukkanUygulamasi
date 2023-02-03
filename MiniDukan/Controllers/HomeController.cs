using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniDukan.Models;
using MiniDukan.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukan.Controllers
{
    public class HomeController : Controller
    {
        private IDukkanRepository repository; //contsractır oluşturduk

        public int SayfaBoyutu = 3;// burda 3 tane gösterilmesi için değişken tanımladık
        public HomeController(IDukkanRepository repo)
        {
            repository = repo;
        }


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View(repository.Urunler);
        //}

        //public ViewResult Index(int urunSayfa = 1)// eğer metot paremetre olmadan çağırılırsada fix olarak bir tane gösterilecek
        //    => View(repository.Urunler.OrderBy(u => u.UrunID).Skip((urunSayfa - 1) * SayfaBoyutu).Take(SayfaBoyutu));
        //// daha önce güsterilenleri bi daha göstermemek için skip kullandık

        public ViewResult Index(int urunSayfa = 1)
            => View(new UrunlerListesiViewModel { Urunler = repository.Urunler.OrderBy(u => u.UrunID).Skip((urunSayfa - 1) * SayfaBoyutu).Take(SayfaBoyutu), SayfalamaBilgi = new SayfalamaBilgi { GuncelSayfa = urunSayfa, SayfaBasiGosterilecekUrun = SayfaBoyutu, ToplamUrunSayisi = repository.Urunler.Count()}}
            );



        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
