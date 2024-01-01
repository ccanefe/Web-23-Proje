using Microsoft.AspNetCore.Mvc;
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
            var doktorlar = await _context.Doktor.Include(d => d.Uzmanlik).ToListAsync();
            return View(doktorlar);
        }
    }
}
