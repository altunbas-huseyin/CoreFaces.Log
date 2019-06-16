using CoreFaces.Log.Models.Models;
using CoreFaces.Log.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.Services
{
    public interface ILogService : IBaseService<CoreFaces.Log.Models.Domain.Log>
    {

    }
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(LogDatabaseContext databaseContext, IOptions<LogSettings> logSettings, IHttpContextAccessor iHttpContextAccessor)
        {
            _logRepository = new StatusRepository(databaseContext, logSettings, iHttpContextAccessor);
        }

        public Models.Domain.Log GetById(Guid id)
        {
            return _logRepository.GetById(id);
        }

        public Guid Save(Guid LogCategoryId, string TableName, string TableRef, string UserId, string Name, string Description)
        {
            Models.Domain.Log status = new Models.Domain.Log
            {
                LogCategoryId = LogCategoryId,
                TableName = TableName,
                TableRef = TableRef,
                UserId = UserId,
                Name = Name,
                Description = Description,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ExceptionMessage = "",
                ExceptionSource = "",
                ExceptionType = "",
                ExceptionUrl = "",
                SessionId = "",
                StatusId = 2,
                TransactionId = ""
            };
            _logRepository.Save(status);
            return status.Id;
        }

        public Guid Save(Models.Domain.Log status)
        {
            _logRepository.Save(status);
            return status.Id;
        }

        public bool Delete(Guid id)
        {
            return _logRepository.Delete(id);
        }

        public bool Update(Models.Domain.Log status)
        {
            return _logRepository.Update(status);

        }

        public List<Models.Domain.Log> GetAll()
        {
            return _logRepository.GetAll();
        }
    }

}
