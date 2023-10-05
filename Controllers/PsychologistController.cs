using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    [Route("Psico")]
    public class PsychologistController : Controller
    {
        private IPsychologistRepository psychologistRepository;

        public PsychologistController(IPsychologistRepository _PsychologistRepo)
        {
            psychologistRepository = _PsychologistRepo;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(psychologistRepository.GetPsychologists());
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null) return NotFound();

            Psychologist? p = psychologistRepository.GetPsychologistById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Psychologist Psychologist)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    psychologistRepository.Update(Psychologist);
                    return View("Index", psychologistRepository.GetPsychologists());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return View("Index", psychologistRepository.GetPsychologists());
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Psychologist? p = psychologistRepository.GetPsychologistById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }

        [HttpPost("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == 0) return NotFound();

            psychologistRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Insert")]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost("Insert")]
        public IActionResult Insert(Psychologist p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    psychologistRepository.Create(p);
                    return View("Index", psychologistRepository.GetPsychologists());
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View();
        }
    }
}
