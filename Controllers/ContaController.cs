using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaServices repository;
        
        public ContaController(IContaServices contaServices)
        {
            repository = contaServices;
        }

        [HttpPost]
        [Route("entrar")]
        public async Task<RequestResponse> EntrarConta([FromBody] ContaModel conta)
        {
            return await repository.EntrarConta(conta.Email, conta.password);
        }
        
    }
}
