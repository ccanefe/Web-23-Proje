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
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                string connectionString = "Server=CAN\\SQLEXPRESS;Database=RandevuDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"; // Veritabanı bağlantı dizini
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = $"SELECT Id FROM Users WHERE Email = @Email AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Password", user.Password);

                        object result = command.ExecuteScalar();

                        if (result != null) // Kullanıcı bulunduysa
                        {
                            // Başarılı giriş, Anasayfa'ya yönlendir
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

                // Kullanıcı bulunamadı veya giriş başarısız oldu
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
            }

            return View(user);
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
                            // Başarılı bir şekilde kaydedildi, Anasayfa'ya yönlendir
                            return RedirectToAction("Index", "Anasayfa");
                        }
                        else
                        {
                            // Kayıt işlemi başarısız oldu
                            // Uygun hata işleme mekanizması burada kullanılabilir
                            // Örneğin, bir hata sayfasına yönlendirilebilir veya hata mesajı gösterilebilir
                        }
                    }
                }
            }

            return View(model);
        }
    }
}
