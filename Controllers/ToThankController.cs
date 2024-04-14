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
    public class ToThankController : ControllerBase
    {
        private readonly IToThankRepository _toThankRepository;

        public ToThankController(IToThankRepository toThankRepository)
        {
            _toThankRepository = toThankRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ToThankModel>>> GetAll()
        {
            List<ToThankModel> toThankList = await _toThankRepository.GetAll();
            return Ok(toThankList);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<ToThankModel>> GetById(long id)
        {
            ToThankModel toThank = await _toThankRepository.GetById(id);
            return Ok(toThank);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ToThankModel>> AddToThank([FromBody] ToThankModel toThankModel)
        {
            ToThankModel newToThank = await _toThankRepository.Add(toThankModel);
            return Created("", newToThank);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<ToThankModel>> UpdateToThank(ToThankModel toThankModel, long id)
        {
            toThankModel.Id = id;
            ToThankModel updateToThank = await _toThankRepository.Update(toThankModel, id);
            return Ok(updateToThank);

        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<string>> DeleteToThank(long id)
        {
            await _toThankRepository.Delete(id);
            return Ok($"Item com o ID: {id} deletado...");
        }
    }
}
