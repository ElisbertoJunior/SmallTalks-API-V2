using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smalltalks.Models;
using Smalltalks.Repository.Interfaces;
using System.Security;
using System.Text.RegularExpressions;

namespace Smalltalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly ISwearingRepository _swearingRepository;

        private readonly ISalutationRepository _salutationRepository;

        private readonly IToThankRepository _tothankRepository;

        public VerificationController(
            ISwearingRepository swearingRepository,
            ISalutationRepository salutationRepository,
            IToThankRepository tothankRepository
            )
        {
            _swearingRepository = swearingRepository;
            _salutationRepository = salutationRepository;
            _tothankRepository = tothankRepository;
        }

        [HttpPost]
        [Authorize]
        [Route("{entry}")]
        public async Task<ActionResult<string>> VerificationSmallTalks(string entry)
        {
            List<SwearingModel> swearingList = await _swearingRepository.GetAll();

            List<SalutationModel> salutationList = await _salutationRepository.GetAll();

            List<ToThankModel> toThankList = await _tothankRepository.GetAll();

            foreach (var swearing in swearingList)
            {
                var swearingInList = Regex.Replace(swearing.Name, @"[^\w\s]", "");
                var entryName = Regex.Replace(entry, @"[^\w\s]", "");

                if (swearingInList.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                {
                    return Ok("Xingamento");
                }

            }

            foreach (var salutation in salutationList)
            {
                var swearingInList = Regex.Replace(salutation.Name, @"[^\w\s]", "");
                var entryName = Regex.Replace(entry, @"[^\w\s]", "");

                if (swearingInList.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                {
                    return Ok("Saudação");
                }

            }

            foreach (var toThank in toThankList)
            {
                var swearingInList = Regex.Replace(toThank.Name, @"[^\w\s]", "");
                var entryName = Regex.Replace(entry, @"[^\w\s]", "");

                if (swearingInList.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                {
                    return Ok("Agradecimento");
                }

            }

            return Ok("Não é SmallTlks");


        }

    }
}
