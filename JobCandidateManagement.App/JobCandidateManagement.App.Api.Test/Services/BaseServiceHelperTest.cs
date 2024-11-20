using AutoMapper;
using JobCandidateManagement.App.Common.Mapper.AutoMapper;
using JobCandidateManagement.App.Data.JobCandidateDbContext;
using JobCandidateManagement.App.MediatR.MediatRService.CandidateInformationService;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.App.Api.Test.Services
{
    public class BaseServiceHelperTest
    {

        public ApplicationDbContext DbContext { get; private set; }
        public IDbContextFactory<ApplicationDbContext> DbContextFactory { get; private set; }
        public IMapper Mapper { get; private set; }
        public InsertCandidateInformationHandler Handler { get; private set; }

        public BaseServiceHelperTest()
        {
            // Setup in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"DatabaseTest_{Guid.NewGuid()}")
                .Options;

            DbContext = new ApplicationDbContext(options);

            // Mock IDbContextFactory
            DbContextFactory = Substitute.For<IDbContextFactory<ApplicationDbContext>>();
            DbContextFactory.CreateDbContextAsync(Arg.Any<CancellationToken>()).Returns(DbContext);

            // Mock IMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CandidateInformationMapperProfile>();
            });
            Mapper = new Mapper(mapperConfig);

            Handler = new InsertCandidateInformationHandler(DbContextFactory, Mapper);
        }

        public void SeedDatabase(Action<ApplicationDbContext> seedAction)
        {
            seedAction(DbContext);
            DbContext.SaveChanges();
        }

        public void ClearDatabase()
        {
            DbContext.Database.EnsureDeleted();
        }

    }
}
