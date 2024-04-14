using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smalltalks.Models;
using Smalltalks.Repository.Interfaces;

namespace Smalltalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwearingController : ControllerBase
    {
        private readonly ISwearingRepository _swearingRepository;

        public SwearingController(ISwearingRepository swearingRepository) 
        { 
            _swearingRepository = swearingRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<SwearingModel>>> GetAll()
        {
            List<SwearingModel> swearingList = await _swearingRepository.GetAll();
            return Ok(swearingList);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<SwearingModel>> GetById(long id)
        {
            SwearingModel swearing = await _swearingRepository.GetById(id);
            return Ok(swearing);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<SwearingModel>> AddSwearing([FromBody] SwearingModel swearing)
        {
            SwearingModel newSwearing = await _swearingRepository.Add(swearing);
            return Created("", newSwearing);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<SwearingModel>> UpdateSwearing(SwearingModel swearing, long id)
        {
            swearing.Id = id;
            SwearingModel updateSwearing = await _swearingRepository.Update(swearing, id);
            return Ok(updateSwearing);

        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<string>> DeleteSwearing(long id)
        {
            await _swearingRepository.Delete(id);
            return Ok($"Item com o ID: {id} deletado...");
        }

    }

}
