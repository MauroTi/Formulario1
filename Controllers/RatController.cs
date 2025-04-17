using Microsoft.AspNetCore.Mvc;
using Formulario1.DAO;
using Formulario1.Models;

namespace Formulario1.Controllers
{
    public class RatController : Controller
    {
        private readonly RatDao dao = new RatDao();

        public IActionResult Index(string nome, string sobrenome, string email, string cidade, string estado)
        {
            var resultados = dao.Listar(nome, sobrenome, email, cidade, estado);
            ViewBag.Filtros = new { nome, sobrenome, email, cidade, estado };
            return View(resultados);
        }
    }
}
