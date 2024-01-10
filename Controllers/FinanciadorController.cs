using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanciadorController : ControllerBase
    {
        private readonly IFinanciadorServices repository;
        
        public FinanciadorController(IFinanciadorServices financiadorServices)
        {
            repository = financiadorServices;
        }

        [HttpPost]
        public async Task<RequestResponse> NovoFinanciador([FromBody] FinanciadorModel financiador)
        {
            return await repository.AdicionarFinanciador(financiador);
        }
    }
}
