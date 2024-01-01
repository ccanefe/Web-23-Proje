using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje.Context;
using Proje.Models;
using System.Threading.Tasks;

namespace Proje.Controllers
{
    public class PoliklinikController : Controller
    {
        private readonly AppDbContext _context;

        public PoliklinikController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> PoliklinikGoruntule()
        {
            List<Uzmanlik> uzmanliklar = await _context.Uzmanliks.ToListAsync();
            return View(uzmanliklar);
        }
    }
}
