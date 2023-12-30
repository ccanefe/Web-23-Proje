using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proje.Models
{
    public class AnaBilimDali
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ana bilim dalı alanı boş geçilemez!")]
        [Display(Name = "Ana Bilim Dalı")]
        public string AnaBilimDaliAdi { get; set; }
    }
}
