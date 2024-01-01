using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proje.Context;
using Proje.Models;
using System.Threading.Tasks;

namespace Proje.Controllers
{
    public class DoktorController : Controller
    {
        private readonly AppDbContext _context;

        public DoktorController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DoktorGoruntule()
        {
            var doktorlar = await _context.Doktors.Include(d => d.Uzmanlik).ToListAsync();
            return View(doktorlar);
        }

        public IActionResult DoktorEkle()
        {
            List<SelectListItem> deger1 = (from x in _context.Uzmanliks.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UzmanlikAdi,
                                               Value = x.Id.ToString()
                                           }).ToList();

            ViewBag.ktgr = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult DoktorEkle(Doktor model, string ktgr)
        {
            if (ModelState.IsValid)
            {
                var uzmanlik = _context.Uzmanliks.FirstOrDefault(u => u.UzmanlikAdi == ktgr);

                string connectionString = "Server=CAN\\SQLEXPRESS;Database=RandevuDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"; // Veritabanı bağlantı dizini

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = $"INSERT INTO Doktors (DoktorAdi, UzmanlikId) VALUES (@DoktorAdi, @UzmanlikId)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@DoktorAdi", model.DoktorAdi);
                        command.Parameters.AddWithValue("@UzmanlikId", uzmanlik.Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("Index", "Anasayfa");
                        }
                    }
                }

                // Eğer ekleme başarısız olursa, modeli tekrar göster
                return View(model);
            }

            // ModelState.IsValid false ise veya hata oluşursa, modeli tekrar göster
            return View(model);
        }



    }
}