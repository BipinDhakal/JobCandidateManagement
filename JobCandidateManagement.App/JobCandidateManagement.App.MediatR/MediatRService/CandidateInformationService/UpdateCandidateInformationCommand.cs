using AutoMapper;
using JobCandidateManagement.App.Data.JobCandidateDbContext;
using JobCandidateManagement.UI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.App.MediatR.MediatRService.CandidateInformationService
{

    /// <summary>
    /// Command to update candidate information
    /// </summary>
    /// <param name="candidateInfo"></param>
    public record class UpdateCandidateInformationCommand(CandidateInformationViewModel candidateInfo) :
        IRequest<ResponseModel<CandidateInformationViewModel>>;


    /// <summary>
    /// Handler to process UpdateCandidateInformationCommand
    /// </summary>
    /// <param name="DbContextFactory"></param>
    /// <param name="Mapper"></param>
    public record UpdateCandidateInformationHandler(
        IDbContextFactory<ApplicationDbContext> DbContextFactory,
        IMapper Mapper) :
        IRequestHandler<UpdateCandidateInformationCommand, ResponseModel<CandidateInformationViewModel>>
    {
        public async Task<ResponseModel<CandidateInformationViewModel>> Handle(
            UpdateCandidateInformationCommand request,
            CancellationToken cancellationToken)
        {
            // Return an error response immediately if candidateInfo is null
            if (request.candidateInfo == null)
            {
                return new ResponseModel<CandidateInformationViewModel>
                {
                    IsSuccess = false,
                    Message = "Candidate information is required.",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            // Initialize the DbContext for database operations
            try
            {
                using (var dbContext = await DbContextFactory.CreateDbContextAsync(cancellationToken))
                {

                    var candidate = await dbContext.CandidateInformations
                        .Where(x => x.Email == request.candidateInfo.Email)
                        .FirstOrDefaultAsync(cancellationToken);


                    if (candidate == null)
                    {
                        return new ResponseModel<CandidateInformationViewModel>
                        {
                            IsSuccess = false,
                            Message = "Candidate not found.",
                            StatusCode = HttpStatusCode.NotFound
                        };
                    }

                    // Map updated information onto the existing candidate entity
                    Mapper.Map(request.candidateInfo, candidate);

                    candidate.UpdatedDate = DateTime.Now;

                    dbContext.Entry(candidate).State = EntityState.Modified;
                    var result = await dbContext.SaveChangesAsync(cancellationToken) > 0;

                    return new ResponseModel<CandidateInformationViewModel>
                    {
                        IsSuccess = result,
                        Result = result ? request.candidateInfo : null,
                        Message = result ? "Updated Successfully" : "Update failed",
                        StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.InternalServerError
                    };

                }
            }
            catch (Exception ex)
            {
                // Return a failure response with exception details
                return new ResponseModel<CandidateInformationViewModel>
                {
                    IsSuccess = false,
                    Message = "An error occurred while updating candidate information.",
                    Exception = ex,
                    StatusCode = HttpStatusCode.InternalServerError
                };

            }

        }
    }

}
