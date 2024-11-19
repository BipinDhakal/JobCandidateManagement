using JobCandidateManagement.App.MediatR.MediatRService.CandidateInformationService;
using JobCandidateManagement.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateManagement.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateInformationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Insert or Update Candidate Information
        /// </summary>
        /// <param name="candidateInformation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertUpdateAsync([FromBody] CandidateInformationViewModel candidateInformation)
        {
            if (ModelState.IsValid) 
            {
                var response = await _mediator.Send(new InsertCandidateInformationCommand(candidateInformation));
                return Ok(candidateInformation);
            }

           return BadRequest();
        }

    }
}
