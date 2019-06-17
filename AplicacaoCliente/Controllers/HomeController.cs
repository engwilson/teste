using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AplicacaoCliente.Models;

namespace AplicacaoCliente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            EmpresaModel objEmpresa = new EmpresaModel();
            ViewBag.ListaEmpresa = objEmpresa.ListarTodos();

            return View();
        }

        [HttpGet]
        public IActionResult Registrar(int? id)
        {
            if (id != null)
            {
                ViewBag.Registro = new EmpresaModel().Carregar(id);
            }
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["Id"] = id.ToString();
            return View();
        }

        public IActionResult ExcluirEmpresa(int id)
        {
            new EmpresaModel().Excluir(id);
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(EmpresaModel dados)
        {
            dados.Inserir();
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
