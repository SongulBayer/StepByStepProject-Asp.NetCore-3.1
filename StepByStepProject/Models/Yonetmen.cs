using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class Yonetmen
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string fullName { get { return Name + " " + LastName; } }
    }
}
