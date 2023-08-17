using livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace PSIUWeb.Controllers
{
    public class NoteController : Controller
    {
        private readonly AppDbContext _context;

        public NoteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Notes.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Notes.Add(note);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Erro: {ex.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, $"Erro, modelo inválido!");
            return View(note);
        }
    }
}