namespace Proje.Models
{
    public class Randevu
    {
        public int RandevuId { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int DoctorId { get; set; }
        public Doctors Doctors { get; set; }

        public int PoliklinikId { get; set; }
        public Poliklinikler Poliklinikler { get; set; }
    }
}
