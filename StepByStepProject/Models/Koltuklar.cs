using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class Koltuklar
    {
        public int Id { get; set; }

        public int BiletId { get; set; }
        public Bilet Bilet { get; set; }

        public string KoltukSira { get; set; }

        public string KoltukSutun { get; set; }
    }
}
