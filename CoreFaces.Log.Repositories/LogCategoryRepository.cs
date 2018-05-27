using CoreFaces.Licensing;
using CoreFaces.Log.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreFaces.Log.Models.Domain;

namespace CoreFaces.Log.Repositories
{

    public interface ILogCategoryRepository : IBaseRepository<Models.Domain.LogCategory>
    {

    }
    public class LogCategoryRepository : Licence, ILogCategoryRepository
    {

        private readonly LogDatabaseContext _databaseContext;

        public LogCategoryRepository(LogDatabaseContext databaseContext, IOptions<LogSettings> statusSettings, IHttpContextAccessor iHttpContextAccessor) : base("Log", iHttpContextAccessor, statusSettings.Value.LogLicenseDomain, statusSettings.Value.LogLicenseKey)
        {
            _databaseContext = databaseContext;
        }

        public bool Delete(Guid id)
        {
            Models.Domain.LogCategory model = this.GetById(id);
            _databaseContext.Remove(model);
            int result = _databaseContext.SaveChanges();
            return Convert.ToBoolean(result);
        }


        public Models.Domain.LogCategory GetById(Guid id)
        {
            Models.Domain.LogCategory model = _databaseContext.Set<Models.Domain.LogCategory>().Where(p => p.Id == id).FirstOrDefault();
            return model;
        }

        public Guid Save(Models.Domain.LogCategory Log)
        {
            _databaseContext.Add(Log);
            _databaseContext.SaveChanges();
            return Log.Id;
        }

        public bool Update(Models.Domain.LogCategory Log)
        {
            _databaseContext.Update(Log);
            int result = _databaseContext.SaveChanges();
            return Convert.ToBoolean(result);
        }

        public List<Models.Domain.LogCategory> GetAll()
        {
            return _databaseContext.Set<Models.Domain.LogCategory>().ToList();
        }
    }

}
