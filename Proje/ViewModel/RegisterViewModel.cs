using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proje.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Telefon { get; set; }

        [Required]
        public string TcNo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
