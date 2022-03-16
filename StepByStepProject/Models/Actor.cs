using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepByStepProject.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


        public int? CountryId { get; set; }
        public Country country { get; set; }

        public Gender Gender { get; set; }


    }
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}

