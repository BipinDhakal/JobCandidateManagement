using JobCandidateManagement.App.Data.JobCandidateDbContext;
using JobCandidateManagement.UI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.App.MediatR.MediatRService.CandidateInformationService
{
    /// <summary>
    /// Query to check if emial already exist or not
    /// </summary>
    /// <param name="candidateInfo"></param>
    public record CheckEmailExistsQuery(CandidateInformationViewModel candidateInfo) : IRequest<bool>;


    /// <summary>
    /// Handler to process CheckEmailExistsQuery
    /// </summary>
    /// <param name="DbContextFactory"></param>
    public record CheckEmailExistsHandler(IDbContextFactory<ApplicationDbContext> DbContextFactory) :
        IRequestHandler<CheckEmailExistsQuery, bool>
    {
        public async Task<bool> Handle(
            CheckEmailExistsQuery request,
            CancellationToken cancellationToken)
        {
            using (var dbContext = await DbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                return await dbContext.CandidateInformations
                .AnyAsync(c => c.Email == request.candidateInfo.Email, cancellationToken);
            }
        }
    }
}
