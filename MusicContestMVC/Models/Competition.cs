using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicContestMVC.Models
{
    public class Competition
    {
        // competion table 
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Date")]
        public DateTime dTime { get; set; }

        public Contestant contestant { get; set; }


    }
}
