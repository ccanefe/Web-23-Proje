using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;


namespace Proje.Models
{
    public class User
    {   
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez!")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Telefon numarası alanı boş geçilemez!")]
        [Display(Name = "Telefon Numarası")]
        public string TelNo { get; set; }

        [Required(ErrorMessage = "TC kimlik numarası alanı boş geçilemez!")]
        [Display(Name = "TC kimlik numarası")]
        public string TcNo { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez!")]
        [Display(Name = "Email")]
        public string Email { get; set; }


    }
}
