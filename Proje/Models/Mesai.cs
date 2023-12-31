using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Proje.Models
{
    public class Mesai
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Doktorun Id'si:")]
        [ValidateNever]
        public int? DoktorId { get; set; }

        [ForeignKey(("DoktorId"))]
        [ValidateNever]
        public Doktor Doktor { get; set; }

        public List<MesaiGunu> CalistigiGunler { get; set; }

        // Çalışma başlangıç ve bitiş saatleri
        public TimeSpan BaslangicZamani { get; set; }
        public TimeSpan BitisZamani { get; set; }

        // Yapıcı metot
        public Mesai()
        {
            CalistigiGunler = new List<MesaiGunu>();
        }
    }
}
