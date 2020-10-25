using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proekt_internetTeh.Models
{
    public class KategorijaSoOglasi
    {
        public List<Oglas> Oglasi { get; set; }
        public int selectedCategory { get; set; }
        public KategorijaSoOglasi()

        {
            Oglasi = new List<Oglas>();
        }
    }
}