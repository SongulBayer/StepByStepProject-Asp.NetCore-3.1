using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class Sinema
    {
        public int Id { get; set; }
        public string SinemaAd { get; set; }

        public Ilce Ilce { get; set; }
        public int? IlceId { get; set; }

        public string Iletisim { get; set; }
        public string Adres { get; set; }

    }
}
