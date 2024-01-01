using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models
{
    public class MesaiGunu
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Mesai Id:")]
        [ValidateNever]
        public int? MesaiId { get; set; }

        [ForeignKey(("MesaiId"))]
        [ValidateNever]
        public Mesai Mesai { get; set; }

        public DayOfWeek Gun { get; set; }



    }
}