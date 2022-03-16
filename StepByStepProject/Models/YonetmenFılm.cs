using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class YonetmenFılm
    {
        public int Id { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int YonetmenId { get; set; }
        public Yonetmen Yonetmen { get; set; }

        public int Sira { get; set; }

        public string YonetmenTip { get; set; }
    }
}
