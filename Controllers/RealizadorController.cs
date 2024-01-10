using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealizadorController : ControllerBase
    {
        private readonly IRealizadorServices repository;

        public RealizadorController(IRealizadorServices realizadorServices)
        {
            repository = realizadorServices;
        }

        [HttpPost]
        public async Task<RequestResponse> NovoRealizador([FromBody] RealizadorModel realizador)
        {
            return await repository.AdicionarRealizador(realizador);
        }
    }
}
