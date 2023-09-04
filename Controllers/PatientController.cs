using Microsoft.AspNetCore.Mvc;
using PSIUWeb.Data.Interface;

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
    }
}
