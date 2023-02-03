using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukan.Models
{
   public interface IDukkanRepository
    {
        IQueryable<Urun> Urunler { get; }
    }
}
