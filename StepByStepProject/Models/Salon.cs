using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public string SalonAd { get; set; }

        public int? SinemaId { get; set; }
        public Sinema Sinema { get; set; }

        public  int? Kapasite { get; set; }



    }
}
