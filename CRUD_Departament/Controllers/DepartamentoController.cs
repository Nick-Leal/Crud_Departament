using CRUD_Departament.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Departament.Controllers
{
    public class DepartamentoController : Controller
    {
        private static IList<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento
            {
                Id = 1,
                Nome = "Bradesco"
            },

            new Departamento
            {
                Id = 2,
                Nome = "Caixa"
            }
        };

        public IActionResult Index()
        {

            return View(departamentos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            departamento.Id = departamentos.Select(i => i.Id).Max() + 1;
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
        public IActionResult Details(long id)
        {
            return View(departamentos.Where(i => i.Id == id).First());
        }
        public IActionResult Edit(long id)
        {
            return View(departamentos.Where(i => i.Id == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(i => i.Id == departamento.Id).First());
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(long id)
        {
            return View(departamentos.Where(i => i.Id == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(i => i.Id == departamento.Id).First());
            return RedirectToAction("Index");

        }
    }
}
