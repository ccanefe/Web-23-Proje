using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Proje.Models
{
    public class Doktor
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        [DisplayName("Doktor Adı-Soyadı:")]
        public string DoktorAdi { get; set; }

        [DisplayName("Uzmanlık Alanı:")]
        [ValidateNever]
        public int? UzmanlikId { get; set; }

        [ForeignKey(("UzmanlikId"))]
        [ValidateNever]
        public Uzmanlik Uzmanlik { get; set; }
    }
}
