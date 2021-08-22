﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicContestMVC.Models
{
    public class Contestant
    {
        // contestant table passing data
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
