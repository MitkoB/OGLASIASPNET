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
        public DateTime pocetnaData { get; set; }
        [Required]
        [Display(Name = "Важи до")]
        public DateTime krajnaData { get; set; }
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
        [Display(Name = "Фотографија")]
        public string slikaUrl { get; set; }
        [Display(Name = "Опис на работата")]

        public string opis { get; set; }
        public virtual List<Rating> rejtinzi { get; set; }
        public Oglas()
        {
            rejtinzi = new List<Rating>();
        }
    }
}