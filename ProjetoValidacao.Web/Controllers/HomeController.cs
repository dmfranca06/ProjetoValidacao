using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ProjetoValidacao.Web.Models;
using System.Diagnostics;
using System.IO;

namespace ProjetoValidacao.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ContaViewModel> contas = null;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44363/api/Conta");
                if (response.IsSuccessStatusCode)
                {
                    contas = response.Content.ReadFromJsonAsync<IEnumerable<ContaViewModel>>().Result;
                } 
            }
            return View(contas);
        }

        public IActionResult Novo()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Novo(ContaViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44363/api/Conta", model);
                    if (response.IsSuccessStatusCode)
                    {
                        model = new ContaViewModel();
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Editar(string nome)
        {
            var model = new ContaViewModel();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44363/api/Conta/{nome}");
                if (response.IsSuccessStatusCode)
                {
                    model = response.Content.ReadFromJsonAsync<ContaViewModel>().Result;
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ContaViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44363/api/Conta", model);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Excluir(string nome)
        {
            var model = new ContaViewModel();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44363/api/Conta/{nome}");
                if (response.IsSuccessStatusCode)
                {
                    model = response.Content.ReadFromJsonAsync<ContaViewModel>().Result;
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(ContaViewModel model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44363/api/Conta/{model.Nome}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}