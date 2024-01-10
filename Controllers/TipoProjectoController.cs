using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProjectoController : ControllerBase
    {
        private readonly ITiposProjectoServices repository;

        public TipoProjectoController(ITiposProjectoServices projectoServices)
        {
            repository = projectoServices;
        }


        [HttpPost]
        public async Task<RequestResponse> NovoTipoProjecto([FromBody] TipoProjectoModel tipoProjecto)
        {
            return await repository.NovoTipoProjecto(tipoProjecto);
        }
    }
}
