using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proekt_internetTeh.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Име")]
        public string ime { get; set; }
        [Required]
        [Display(Name = "Објаснување")]
        public string desc { get; set; }
        public virtual  List<Oglas> Oglasi { get; set; }
        public Category()
        {
            Oglasi = new List<Oglas>();
        }

    }
}