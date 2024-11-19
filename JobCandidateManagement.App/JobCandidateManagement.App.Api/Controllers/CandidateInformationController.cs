using JobCandidateManagement.App.MediatR.MediatRService.CandidateInformationService;
using JobCandidateManagement.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
                var response = await HandleInsertOrUpdate(candidateInformation);
                return response.IsSuccess
                    ? StatusCode((int)response.StatusCode, response)
                    : StatusCode((int)HttpStatusCode.InternalServerError, response);
            }

           return BadRequest();
        }

        /// <summary>
        /// Handles for Insert or Update operation
        /// Chacks if Email exists or not
        /// </summary>
        /// <param name="candidateInformation"></param>
        /// <returns></returns>
        private async Task<ResponseModel<CandidateInformationViewModel>> HandleInsertOrUpdate(CandidateInformationViewModel candidateInformation)
        {
            try
            {
                bool isEmailAlreadyExist = await _mediator.Send(new CheckEmailExistsQuery(candidateInformation));

                return isEmailAlreadyExist
                    ? await _mediator.Send(new UpdateCandidateInformationCommand(candidateInformation))
                    : await _mediator.Send(new InsertCandidateInformationCommand(candidateInformation));
            }
            catch (Exception ex)
            {
                return new ResponseModel<CandidateInformationViewModel>
                {
                    IsSuccess = false,
                    Message = "An error occurred while processing candidate information.",
                    Exception = ex,
                    StatusCode = HttpStatusCode.InternalServerError
                };

            }

        }


    }
}
