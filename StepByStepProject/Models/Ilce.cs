using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace StepByStepProject.Models
{
    public class Ilce
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        public string IlceAd { get; set; }

        public Il Il { get; set; }
        public int? IlId { get; set; }
    }
}
