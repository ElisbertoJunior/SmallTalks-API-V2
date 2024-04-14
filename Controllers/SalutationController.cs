using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smalltalks.Models;
using Smalltalks.Repository;
using Smalltalks.Repository.Interfaces;

namespace Smalltalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalutationController : ControllerBase
    {
        private readonly ISalutationRepository _salutationRepository;

        public SalutationController(ISalutationRepository salutationRepository)
        {
            _salutationRepository = salutationRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<SalutationModel>>> GetAll()
        {
            List<SalutationModel> salutationList = await _salutationRepository.GetAll();
            return Ok(salutationList);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<SalutationModel>> GetById(long id)
        {
            SalutationModel salutation = await _salutationRepository.GetById(id);
            return Ok(salutation);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<SalutationModel>> AddSalutation([FromBody] SalutationModel salutationModel)
        {
            SalutationModel newSalutation = await _salutationRepository.Add(salutationModel);
            return Created("", newSalutation);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<SalutationModel>> UpdateSalutation(SalutationModel salutationModel, long id)
        {
            salutationModel.Id = id;
            SalutationModel updateSalutation = await _salutationRepository.Update(salutationModel, id);
            return Ok(updateSalutation);

        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<string>> DeleteSalutation(long id)
        {
            await _salutationRepository.Delete(id);
            return Ok($"Item com o ID: {id} deletado...");
        }
    }
}
