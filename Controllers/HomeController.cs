using System.Diagnostics;
using Formulario1.DAO;
using Formulario1.Models;
using Microsoft.AspNetCore.Mvc;
using Formulario1.DAO; // Adicione essa referência

namespace Formulario1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       

public IActionResult TestarConexao()
    {
        ConexaoDAO dao = new ConexaoDAO();
        var conexao = dao.Conectar();

        if (conexao != null)
        {
            ViewBag.Mensagem = "Conexão com o banco de dados realizada com sucesso!";
            dao.Desconectar();
        }
        else
        {
            ViewBag.Mensagem = "Falha na conexão com o banco de dados.";
        }

        return View();
    }

}
}
