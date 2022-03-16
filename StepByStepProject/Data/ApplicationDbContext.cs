using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StepByStepProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStepProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Film> Film { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Actor> Actors{ get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<FilmAktor> FilmAktors{ get; set; }
        public DbSet<Yonetmen> Yonetmen{ get; set; }
        public DbSet<YonetmenFılm> YonetmenFılm { get; set; }
        public DbSet<Gosterimler> Gosterimler { get; set; }
        public DbSet<Il> Il{ get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Koltuklar> Koltuklar { get; set; }
        public DbSet<Salon> Salon { get; set; }
        public DbSet<Seans> Seans { get; set; }
        public DbSet<Sinema> Sinema { get; set; }
        public DbSet<Bilet> Bilet { get; set; }









    }
}
