using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proje.Context;
using Proje.Models;

namespace Proje.Controllers
{

    public class AccountController : Controller
    {
        private readonly DbContext _context;

        public AccountController()
        {
            _context = new AppDbContext(); 
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User u)
        {
            var user = _context.Set<User>().FirstOrDefault(x => x.Email == u.Email && x.Password == u.Password);
            if (user == null) return View("Error");
            else return RedirectToAction("AnasayfaGoruntule", "Anasayfa");
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = "Server=CAN\\SQLEXPRESS;Database=RandevuDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"; // Veritabanı bağlantı dizini
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = $"INSERT INTO Users (Name, Surname, TelNo, TcNo, Email, Password) " +
                        $"VALUES (@Name, @Surname, @TelNo, @TcNo, @Email, @Password)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", model.Name);
                        command.Parameters.AddWithValue("@Surname", model.Surname);
                        command.Parameters.AddWithValue("@TelNo", model.TelNo);
                        command.Parameters.AddWithValue("@TcNo", model.TcNo);
                        command.Parameters.AddWithValue("@Email", model.Email);
                        command.Parameters.AddWithValue("@Password", model.Password);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("Index", "Anasayfa");
                        }
                    }
                }
            }

            return View(model);
        }
    }
}
