using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukan.Models.ViewModels
{
    public class UrunlerListesiViewModel
    {
        public IEnumerable<Urun> Urunler { get; set; }
        public SayfalamaBilgi SayfalamaBilgi { get; set; }
    }
}
