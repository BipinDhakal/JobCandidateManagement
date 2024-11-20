using JobCandidateManagement.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.App.Data.EntityMap
{
    public class CandidateInformationMap : IEntityTypeConfiguration<CandidateInformation>
    {
        public void Configure(EntityTypeBuilder<CandidateInformation> builder)
        {
            builder.HasKey(x => x.Email);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(x => x.CallTimeInterval).IsRequired(false).HasMaxLength(250).HasColumnType("nvarchar");
            builder.Property(x => x.LinkedInProfileUrl).IsRequired(false).HasMaxLength(250).HasColumnType("nvarchar");
            builder.Property(x => x.GitHubProfileUrl).IsRequired(false).HasMaxLength(250).HasColumnType("nvarchar");
            builder.Property(x => x.Comments).IsRequired().HasColumnType("nvarchar(max)");

            builder.CommonPropertiesMap();
        }
    }
}
