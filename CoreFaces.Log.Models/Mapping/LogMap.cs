using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.Models.Mapping
{
   public class LogMap
    {
        public LogMap(EntityTypeBuilder<Log.Models.Domain.Log> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.LogCategoryId).IsRequired();
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.Description);
            entityBuilder.Property(t => t.UserId);
            entityBuilder.Property(t => t.SessionId);
            entityBuilder.Property(t => t.ExceptionType);
            entityBuilder.Property(t => t.ExceptionMessage);
            entityBuilder.Property(t => t.ExceptionSource);
            entityBuilder.Property(t => t.ExceptionUrl);
            entityBuilder.Property(t => t.StatusId).IsRequired();
            entityBuilder.Property(t => t.CreateDate).IsRequired();
            entityBuilder.Property(t => t.UpdateDate).IsRequired();
        }
    }
}
