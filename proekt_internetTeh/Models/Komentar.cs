using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proekt_internetTeh.Models
{
    public class Komentar
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public int oglasID { get; set; }
        [Display(Name ="Коментар")]
        public string komentar { get; set; }
    }
}