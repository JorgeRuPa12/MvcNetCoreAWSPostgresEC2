using Microsoft.AspNetCore.Mvc;
using MvcNetCoreAWSPostgresEC2.Models;
using MvcNetCoreAWSPostgresEC2.Repositories;

namespace MvcNetCoreAWSPostgresEC2.Controllers
{
    public class DepartamentoController : Controller
    {
        private RepositoryHospitales repo;
        public DepartamentoController(RepositoryHospitales repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> depts = await this.repo.GetDepartamentosAsync();
            return View(depts);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(id);
            return View(dept);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.repo.InsertDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
    }
}
