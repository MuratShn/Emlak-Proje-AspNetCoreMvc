using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmlakOfis.Models;

namespace EmlakOfis.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database=EmlakProje;Integrated Security=True");
        }
        public DbSet<Emlakci> emlakcis { get; set; }
        public DbSet<Ev> evs { get; set; }
        public DbSet<Sehir> sehirs { get; set; }
        public DbSet<Kategori> kategoris { get; set; }
        public DbSet<Adminn> admins { get; set; }

    }
}
