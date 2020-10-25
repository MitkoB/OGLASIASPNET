using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proekt_internetTeh.Models
{
    public class OglasToCategoryModel
    {
        public List<Category> categories { get; set; }
        public int selectedCategory { get; set; }
        public int selectedOglas { get; set; }

        public OglasToCategoryModel()

        {
            categories = new List<Category>();
        }
    }
}