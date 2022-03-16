using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class Seans
    {
        public int Id { get; set; }

        public Gosterimler Gosterimler { get; set; }
        public int GosterimId { get; set; }

        public DateTime SeansBaslangic { get; set; }

    }
}
