using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string FilmAd { get; set; }
        public int? Yil { get; set; }
        public int? Uzunluk { get; set; }
        public double? IMDB { get; set; }
        public string Konu { get; set; }
        public string Afis { get; set; }
        public string Fragman { get; set; }

        public int? KategoriId { get; set; }
        public Kategori Kategori  { get; set; }

        public int? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
