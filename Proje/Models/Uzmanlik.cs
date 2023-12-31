using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Proje.Models
{
    public class Uzmanlik
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Uzmanlık adı alanı boş bırakılamaz.")]
        [MaxLength(40)]
        [DisplayName("Uzmanlık Alanı: ")]
        public string UzmanlikAdi { get; set; }

        [Required(ErrorMessage = "The field for specialization name cannot be left empty.")]
        [MaxLength(40)]
        [DisplayName("Field of Expertise: ")]
        public string UzmanlikAdiEng { get; set; }
    }
}
