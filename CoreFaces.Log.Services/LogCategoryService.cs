using CoreFaces.Log.Models.Models;
using CoreFaces.Log.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.Services
{
    public interface ILogCategoryService : IBaseService<CoreFaces.Log.Models.Domain.LogCategory>
    {

    }
    public class LogCategoryService : ILogCategoryService
    {
        private readonly ILogCategoryRepository _logCategoryRepository;
        public LogCategoryService(LogDatabaseContext databaseContext, IOptions<LogSettings> logSettings, IHttpContextAccessor iHttpContextAccessor)
        {
            _logCategoryRepository = new LogCategoryRepository(databaseContext, logSettings, iHttpContextAccessor);
        }

        public Models.Domain.LogCategory GetById(Guid id)
        {
            return _logCategoryRepository.GetById(id);
        }

        public Guid Save(Models.Domain.LogCategory status)
        {
            _logCategoryRepository.Save(status);
            return status.Id;
        }

        public bool Delete(Guid id)
        {
            return _logCategoryRepository.Delete(id);
        }

        public bool Update(Models.Domain.LogCategory status)
        {
            return _logCategoryRepository.Update(status);

        }

        public List<Models.Domain.LogCategory> GetAll()
        {
            return _logCategoryRepository.GetAll();
        }
    }

}
