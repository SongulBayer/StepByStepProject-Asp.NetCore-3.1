using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class FilmAktor
    {
        public int Id { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        public string Rol { get; set; }

        public int? Sira { get; set; }//başrol oyuncu falan
    }
}
