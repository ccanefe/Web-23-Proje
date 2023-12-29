using System.ComponentModel.DataAnnotations;

namespace Proje.Models
{
    public class Doctors
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Doktorun çalıştığı ana bilim dalı alanı boş geçilemez!")]
        [Display(Name = "Çalıştığı Ana Bilim Dalı")]
        public string AnaBilimDali { get; set; }

        [Required(ErrorMessage = "Doktorun çalıştığı poliklinik alanı boş geçilemez!")]
        [Display(Name = "Çalıştığı Poliklinik")]
        public string Poliklinik { get; set; }

        [Required(ErrorMessage = "Doktorun çalıştığı günler boş geçilemez!")]
        [Display(Name = "Çalıştığı Günler")]
        public string[] CalistigiGunler { get; set; }

        [Required(ErrorMessage = "Doktorun çalıştığı günler boş geçilemez!")]
        [Display(Name = "Çalıştığı Günler")]
        public List<TimeSpan> GunlukCalismaSaatleri { get; set; }

    }
}
