namespace Proje.Models
{
    public class Poliklinikler
    {
        public int PolikliniklerId { get; set; } 

        public string PoliklinikAdi { get; set; }

        public int AnaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; }

    }
}
