using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class Bilet
    {
        public int Id { get; set; }

        public Seans Seans { get; set; }
        public int SeansId { get; set; }

        public DateTime AlisZamani { get; set; }
        public double Ucret { get; set; }

        //pubic int User
        public int Adet { get; set; }

    }
}
