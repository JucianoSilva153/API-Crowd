using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoFinancimentoController : ControllerBase
    {
        private readonly ITipoFinanciamentoServices repository;

        public TipoFinancimentoController(ITipoFinanciamentoServices tipoFinanciamentoServices)
        {
            repository = tipoFinanciamentoServices;
        }

        [HttpPost]
        public async Task<RequestResponse> NovoTipoFinanciamento([FromBody] TipoFinanciamentoModel tipoFinanciamento)
        {
            return await repository.NovoTipoFinanciamento(tipoFinanciamento);
        }
    }
}
