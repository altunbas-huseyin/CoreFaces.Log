using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.Models.Mapping
{
    public class LogCategoryMap
    {
        public LogCategoryMap(EntityTypeBuilder<Log.Models.Domain.LogCategory> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.Description);
            entityBuilder.Property(t => t.StatusId).IsRequired();
            entityBuilder.Property(t => t.CreateDate).IsRequired();
            entityBuilder.Property(t => t.UpdateDate).IsRequired();

            //Uniq Index
            entityBuilder.HasIndex(t => new { t.Name }).IsUnique();
        }
    }
}
