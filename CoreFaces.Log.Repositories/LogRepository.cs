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

    public interface ILogRepository : IBaseRepository<Models.Domain.Log>
    {
        List<Models.Domain.Log> GetByTableName(string tableName);
        List<Models.Domain.Log> Get(Func<Models.Domain.Log, bool> filter = null);
    }
    public class StatusRepository : Licence, ILogRepository
    {

        private readonly LogDatabaseContext _databaseContext;

        public StatusRepository(LogDatabaseContext databaseContext, IOptions<LogSettings> statusSettings, IHttpContextAccessor iHttpContextAccessor) : base("Log", iHttpContextAccessor, statusSettings.Value.LogLicenseDomain, statusSettings.Value.LogLicenseKey)
        {
            _databaseContext = databaseContext;
        }

        public bool Delete(Guid id)
        {
            Models.Domain.Log model = this.GetById(id);
            _databaseContext.Remove(model);
            int result = _databaseContext.SaveChanges();
            return Convert.ToBoolean(result);
        }

        public Models.Domain.Log GetByName(string name)
        {
            Models.Domain.Log model = _databaseContext.Set<Models.Domain.Log>().Where(p => p.Name == name).FirstOrDefault();
            return model;
        }

        public Models.Domain.Log GetById(Guid id)
        {
            Models.Domain.Log model = _databaseContext.Set<Models.Domain.Log>().Where(p => p.Id == id).FirstOrDefault();
            return model;
        }

        public Guid Save(Models.Domain.Log Log)
        {
            _databaseContext.Add(Log);
            _databaseContext.SaveChanges();
            return Log.Id;
        }

        public bool Update(Models.Domain.Log Log)
        {
            _databaseContext.Update(Log);
            int result = _databaseContext.SaveChanges();
            return Convert.ToBoolean(result);
        }

        public List<Models.Domain.Log> GetAll()
        {
            return _databaseContext.Set<Models.Domain.Log>().ToList();
        }

        public List<Models.Domain.Log> GetByTableName(string tableName)
        {
            List<Models.Domain.Log> models = _databaseContext.Set<Models.Domain.Log>().Where(p => p.TableName == tableName).ToList();
            return models;
        }

        public List<Models.Domain.Log> Get(Func<Models.Domain.Log, bool> filter = null)
        {
            List<Models.Domain.Log> models = _databaseContext.Set<Models.Domain.Log>().Where(filter ?? (s => true)).ToList();
            return models;
        }
    }

}
