using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDukan.Models
{
    public class MiniDukkanContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-O9RRR03;database=MiniDukkanDB; Trusted_Connection=True");
        }
        public MiniDukkanContext(DbContextOptions<MiniDukkanContext> options) : base(options)
        {

        }
        public DbSet<Urun> Urunler { get; set; }
    }
}
