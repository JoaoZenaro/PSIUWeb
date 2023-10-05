using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class PsychologistController : Controller
    {
        private IPsychologistRepository psychologistRepository;

        public PsychologistController(IPsychologistRepository _PsychologistRepo)
        {
            psychologistRepository = _PsychologistRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(psychologistRepository.GetPsychologists());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null) return NotFound();

            Psychologist? p = psychologistRepository.GetPsychologistById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }

        [HttpPost]
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

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Psychologist? p = psychologistRepository.GetPsychologistById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == 0) return NotFound();

            psychologistRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
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
