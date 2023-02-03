using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukan.Models
{
    public class Urun
    {
        public long UrunID { get; set; }
        public string UrunAd { get; set; }
        public string Açıklama { get; set; }
        [Column(TypeName="decimal(6,2)")]//6 karekter olsun virgulden sonrada 2 karekter olsun başta 
        public decimal fiyat { get; set; }
        public string Kategori { get; set; }


    }
}
