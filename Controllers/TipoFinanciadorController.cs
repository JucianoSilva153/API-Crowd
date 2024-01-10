using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoFinanciadorController : ControllerBase
    {
        private readonly ITipoFinanciadorServices repository;

        public TipoFinanciadorController(ITipoFinanciadorServices tipoFinanciadorServices)
        {
            repository = tipoFinanciadorServices;
        }

        [HttpPost]
        public async Task<RequestResponse> NovoTipoFinanciador([FromBody] TipoFinanciadorModel tipoFinanciador)
        {
            return await repository.NovoTipoFinanciador(tipoFinanciador);
        }
        
    }
}
