using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class PatientController : Controller
    {
        private IPatientRepository patientRepository;

        public PatientController(IPatientRepository _patientRepo)
        {
            patientRepository = _patientRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(patientRepository.GetPatients());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null) return NotFound();

            Patient? p = patientRepository.GetPatientById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    patientRepository.Update(patient);
                    return View("Index", patientRepository.GetPatients());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }
            return View("Index", patientRepository.GetPatients());
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            Patient? p = patientRepository.GetPatientById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == 0) return NotFound();

            patientRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Patient p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    patientRepository.Create(p);
                    return View("Index", patientRepository.GetPatients());
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
