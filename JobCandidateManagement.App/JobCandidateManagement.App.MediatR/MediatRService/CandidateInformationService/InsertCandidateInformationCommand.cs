using AutoMapper;
using JobCandidateManagement.App.Data.JobCandidateDbContext;
using JobCandidateManagement.App.Models;
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
    /// Command to insert candidate information
    /// </summary>
    /// <param name="candidateInfo"></param>
    public record InsertCandidateInformationCommand(CandidateInformationViewModel candidateInfo) :
        IRequest<ResponseModel<CandidateInformationViewModel>>;


    /// <summary>
    /// Handle to process InsertCandidateInformationCommand
    /// </summary>
    /// <param name="DbContextFactory"></param>
    /// <param name="Mapper"></param>
    public record InsertCandidateInformationHandler(
        IDbContextFactory<ApplicationDbContext> DbContextFactory,
        IMapper Mapper) :
        IRequestHandler<InsertCandidateInformationCommand, ResponseModel<CandidateInformationViewModel>>
    {   
        public async Task<ResponseModel<CandidateInformationViewModel>> Handle(
            InsertCandidateInformationCommand request, 
            CancellationToken cancellationToken)
        {
            
            // Return an error response if candidateInfo is null
            if (request.candidateInfo == null)
            {
                return new ResponseModel<CandidateInformationViewModel>
                {
                    IsSuccess = false,
                    Message = "Candidate information cannot be null.",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            // Initialize the DbContext for database operations
            try
            {
                using (var dbContext = await DbContextFactory.CreateDbContextAsync(cancellationToken))
                {
                    var dbCandidateInformation = Mapper.Map<CandidateInformation>(request.candidateInfo);
                    dbCandidateInformation.CreatedDate = DateTime.Now;

                    // Add and save the candidate information in the database
                    await dbContext.CandidateInformations.AddAsync(dbCandidateInformation, cancellationToken);
                    var result = await dbContext.SaveChangesAsync(cancellationToken);

                    return new ResponseModel<CandidateInformationViewModel>
                    {
                        IsSuccess = result > 0,
                        Result = result > 0 ? request.candidateInfo : null,
                        Message = result > 0 ? "Saved Successfully" : "Save failed",
                        StatusCode = result > 0 ? HttpStatusCode.OK : HttpStatusCode.InternalServerError
                    };
                }
            }
            catch (Exception ex)
            {
                // Return a failure response with exception details
                return new ResponseModel<CandidateInformationViewModel>
                {
                    IsSuccess = false,
                    Message = "An error occurred while saving candidate information.",
                    Exception = ex,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

        }
    }


}
