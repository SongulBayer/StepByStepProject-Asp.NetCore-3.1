using Microsoft.AspNetCore.Mvc;
using StepByStepProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Controllers
{
    /* VizyonController ında vizyondaki filimlere bakılacak ve vizyondaki filimlere ait bilgiler getirilecek */
        public class VizyonController : Controller
    {
        public readonly ApplicationDbContext _context;

        public VizyonController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var filmList = (from g in _context.Gosterimler
                            join f in _context.Film on g.FilmId equals f.Id
                            select new FilmDTO
                            {
                                FilmId = f.Id,
                                Adi = f.FilmAd,
                                Yil = f.Yil,
                                Uzunluk = f.Uzunluk,
                                Konu = f.Konu,
                                BaslangicZamani = g.Baslangic,
                                BitisZamani = g.Bitis,
                                Tur = f.Kategori.KategoriName,
                                Afis = f.Afis,
                                Fragman = f.Fragman
                            })
                          .OrderBy(x => x.BaslangicZamani).ToList();

            foreach (var item in filmList)
            {
                item.Oyuncular = GetirAktorListesi(item.FilmId);
                item.Yonetmenler = GetirYonetmenListesi(item.FilmId);
            }
            var vizyon = filmList.Where(x => (x.BaslangicZamani <= DateTime.Now && x.BitisZamani >= DateTime.Now)).ToList();

            return View(vizyon);
        }
        public string GetirAktorListesi(int? FKFilmId)
        {
            string AktorAdSoyad = "";
            var aktorList = (from a in _context.FilmAktors.Where(x => x.FilmId == FKFilmId)
                             select new
                             {
                                 OyuncuId = a.ActorId,
                                 Aktor = a.Actor.fullName,
                                 Sira = a.Sira,

                             }).OrderBy(x => x.Sira).ToList();

            foreach (var item in aktorList)
            {
                AktorAdSoyad += " " + item.Aktor+" ";
            }
            return AktorAdSoyad;
        }
        public string GetirYonetmenListesi (int? FKFilmID)
        {
            string YonetmenAdSoyad = "";
            var yonetmenList = (from y in _context.YonetmenFılm.Where(x => x.FilmId == FKFilmID)
                                select new
                                {
                                    YonetmenId = y.YonetmenId,
                                    Yonetmen = y.Yonetmen.fullName,
                                    Sira = y.Sira
                                }).OrderBy(x => x.Sira).ToList();
            foreach (var item in yonetmenList)
            {
                YonetmenAdSoyad += " " + item.Yonetmen + " ";
            }
            return YonetmenAdSoyad;
        }
    }
    public class FilmDTO
    {
        public string Adi { get; internal set; }
        public int? Yil { get; internal set; }
        public int? Uzunluk { get; internal set; }
        public string Konu { get; internal set; }
        public string Oyuncular { get; internal set; }
        public string Yonetmenler { get; internal set; }
        public DateTime? BaslangicZamani { get; internal set; }
        public DateTime? BitisZamani { get; internal set; }
        public string Tur { get; internal set; }
        public int FilmId { get; internal set; }
        public string Afis { get; internal set; }
        public string Fragman { get; internal set; }

    }
}
//DTO  : Data Transfer Object