using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class Gosterimler
    {
        public int Id { get; set; }

        public Film Film { get; set; }
        public int FilmId { get; set; }

        public Salon Salon { get; set; }
        public int SalonId { get; set; }

        // public string SalonNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Baslangic { get; set; }
        [DataType(DataType.Date)]
        public DateTime Bitis { get; set; }

        public bool? AltYazi { get; set; }

        public int SinemaId { get; set; }
        public Sinema Sinema { get; set; }

       // public DateTime GosterimBaslangic { get; set; }
       // public DateTime GosterimBitis { get; set; }


    }
}
