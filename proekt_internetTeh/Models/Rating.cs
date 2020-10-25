using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proekt_internetTeh.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int Rate { get; set; }
        public string email { get; set; }
        public List<int> ratings { get; set; }
        public virtual int oglas { get; set; }
        public Rating()
        {
            ratings = new List<int>();
        }
    }
}