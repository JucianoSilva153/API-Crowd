using API.Entities;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanciamentoProjectoController : ControllerBase
    {
        private readonly IFinanciamentoProjectoServices repository;

        public FinanciamentoProjectoController(IFinanciamentoProjectoServices _context)
        {
            repository = _context;
        }

        [HttpPost]
        public async Task<RequestResponse> NovoFinanciamento(
            [FromBody] FinanciamentoProjectoModel financiamento
        )
        {
            return await repository.FinanciarProjecto(financiamento);
        }

        [HttpGet]
        [Route("financiadores/projectos/{id}")]
        public async Task<RequestResponse> NumeroFinanciadores(int id)
        {
            return await repository.NumeroFinanciadoresProjecto(id);
        }

        [HttpGet]
        [Route("diasRestantes/projectos/{id}")]
        public async Task<RequestResponse> DiasDeFinanciamentoRestantes(int id)
        {
            return await repository.DiasRestantes(id);
        }

        [HttpGet]
        [Route("doacoes/projectos/{id}")]
        public async Task<RequestResponse> TotalArrecadado(int id)
        {
            return await repository.FundoTotal(id);
        }
    }
}
