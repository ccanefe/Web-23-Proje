using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models
{
    public class Doctors
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [ForeignKey("AnaBilimDali")]
        public int AnaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; }

        [ForeignKey("Poliklinikler")]
        public int PolikliniklerId { get; set; }
        public Poliklinikler Poliklinikler { get; set; }    

        public List<CalismaZamani> CalismaZamani { get; set; }  
        public List<Randevu> Randevus { get; set; }



    }
}
