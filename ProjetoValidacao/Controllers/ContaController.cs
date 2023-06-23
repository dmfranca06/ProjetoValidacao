using Microsoft.AspNetCore.Mvc;
using ProjetoValidacao.API.Repositorio;
using ProjetoValidacao.Models;
using RestSharp;

namespace ProjetoValidacao.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
        private readonly ContaRepositorio _repositorio;

        #region Contrutor
        public ContaController(AppDbContext context)
        {
            _repositorio = new ContaRepositorio(context);
        }
        #endregion

        #region Actions
        [HttpGet]
        [Route("/viacep")]
        public async Task<IActionResult> GetRest()
        {
            var url = "http://viacep.com.br/ws/01001000/json/";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            RestResponse response = client.Execute(request);
            var Output = response.Content;

            return Ok(Output);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await Task.Run(() => _repositorio.Listar());
            return Ok(lst);
        }

        [HttpGet]
        [Route("{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            var conta = await Task.Run(() => _repositorio.Obter(nome));
            return Ok(conta);
        }

        [HttpPost]
        public IActionResult Post(Conta model)
        {
            _repositorio.Inserir(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Conta model)
        {
            _repositorio.Alterar(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Conta model)
        {
            _repositorio.Excluir(model);
            return Ok();
        } 

        [HttpDelete]
        [Route("{nome}")]
        public async Task<IActionResult> Delete(string nome)
        {
            var conta = _repositorio.Obter(nome);
            await Task.Run(() => _repositorio.Excluir(conta));
            return Ok();
        } 
        #endregion
    }
}
