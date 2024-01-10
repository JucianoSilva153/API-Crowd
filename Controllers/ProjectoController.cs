using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectoController : ControllerBase
    {
        private readonly IProjectoServices repository;
        
        public ProjectoController(IProjectoServices projectoServices)
        {
            repository = projectoServices;
        }

        [HttpGet]
        public async Task<RequestResponse> ListarProjectos()
        {
            return await repository.RetornarProjectos();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<RequestResponse> RetornaProjecto(int id)
        {
            return await repository.RetornarProjecto(id);
        }

        [HttpPost]
        public async Task<RequestResponse> NovoProjecto([FromBody] ProjectoModel projecto)
        {
            return await repository.AdicionarNovoProjecto(projecto);
        }

        [HttpDelete]
        [Route("{ProjectoId}")]
        public async Task<RequestResponse> RemoverProjecto(int ProjectoId)
        {
            return await repository.ApagarProjecto(ProjectoId);
        }

        [HttpPut]
        public async Task<RequestResponse> AtualizarProjecto([FromBody] ProjectoModel projecto)
        {
            return await repository.AtualizarProjecto(projecto);
        }
    }
}
