using API.Entities;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalhesController : ControllerBase
    {
        private readonly IDetalhesServices repository;

        public DetalhesController(IDetalhesServices detalhesServices)
        {
            repository = detalhesServices;
        }

        [HttpPost]
        public async Task<RequestResponse> NovoDetalhe([FromBody] DetalheModel detalhe)
        {
            return await repository.AdicionarDetalhe(detalhe);
        }
    }
}
