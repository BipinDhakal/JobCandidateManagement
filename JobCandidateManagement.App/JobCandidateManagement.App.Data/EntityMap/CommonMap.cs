using JobCandidateManagement.App.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.App.Data.EntityMap
{
    public static class CommonMap
    {
        public static void CommonPropertiesMap<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : Common
        {
            builder.Property(x=>x.CreatedBy).IsRequired(false);
            builder.Property(x => x.CreatedDate).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false);
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.DeletedBy).IsRequired(false);
            builder.Property(x => x.DeletedDate).IsRequired(false);
        }
    }
}
