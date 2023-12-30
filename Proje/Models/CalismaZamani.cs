using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Proje.Models
{
    public class CalismaZamani
    {
        public int CalismaZamaniId { get; set; }

        [Required(ErrorMessage = "Doktorun çalıştığı günler boş geçilemez!")]
        [Display(Name = "Çalıştığı Günler")]
        public DayOfWeek CalistigiGunler { get; set; }

        [Required(ErrorMessage = "Doktorun çalıştığı günler boş geçilemez!")]
        [Display(Name = "Çalıştığı Günler")]
        public TimeSpan BaslangicZamani { get; set; }
        public TimeSpan BitisZamani { get; set; }

        [ForeignKey("Doctors")]
        public int DoktorId { get; set; }
        public Doctors Doctors { get; set; }
    }
}
