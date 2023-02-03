using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukan.Models
{
    public class EFDukkanRepository : IDukkanRepository
    {
        private MiniDukkanContext context;

        public EFDukkanRepository(MiniDukkanContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Urun> Urunler => context.Urunler;
    }
}
