using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Proje.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; }

        public DateTime Tarih { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public int? UserId { get; set; }

        public User? User { get; set; }

        [ForeignKey("DoktorId")]
        [ValidateNever]
        public int? DoktorId { get; set; }

        public Doktor? Doktor { get; set; }
    }
}
