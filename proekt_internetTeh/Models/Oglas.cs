using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proekt_internetTeh.Models
{
    public class Oglas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Наслов")]
        public string zanimanje { get; set; }
        [Display(Name = "Категорија")]
        public virtual Category kategorija { get; set; }
        [Required]
        [Display(Name = "Дата на објавување")]
        public Nullable<DateTime> pocetnaData { get; set; }
        [Required]
        [Display(Name = "Важи до")]
        public Nullable<DateTime> krajnaData { get; set; }
        [Required]
        [Display(Name = "Правно лице")]

        public string pravnoLice { get; set; }
        [Required]
        [Display(Name = "Општина")]

        public string opstina { get; set; }
        [Required]
        [Display(Name = "Адреса")]

        public string adresa { get; set; }
        [Required]
        [Display(Name = "Маил")]

        public string email { get; set; }
        [Required]
        [Display(Name = "Телефонски број")]

        public string telBroj { get; set; }
        [Display(Name = "Фотографија 1")]
        public string slikaUrl { get; set; }
        [Display(Name = "Опис на оглас")]
       
        public string opis { get; set; }
        [Display(Name = "Цена")]
        public int cena { get; set; }
        [Display(Name = "Фотографија 2")]
        public string urlSlika2 { get; set; }
      
    }
}