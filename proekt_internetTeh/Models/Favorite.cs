using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proekt_internetTeh.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public virtual List<Oglas> OmileniOglasi {get;set;}
        public Favorite()
        {
            OmileniOglasi = new List<Oglas>();
        }
    }
}