using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicContestMVC.Models
{
    public class Organizer
    {
        // Organizer table model
        public int id { get; set; }

        [Display(Name = "Email ")]
        public string Email { get; set; }


        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
