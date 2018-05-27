using CoreFaces.Log.Models.Models;
using CoreFaces.Log.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace CoreFaces.Log.Services
{
    public interface ILogSchemaService
    {
        bool DropTables();
        bool EnsureCreated();
    }
    public class LogSchemaService : ILogSchemaService
    {
        private readonly LogSchemaRepository _logSchemaRepository;
        public LogSchemaService(LogDatabaseContext databaseContext, IOptions<LogSettings> logSettings, IHttpContextAccessor iHttpContextAccessor)
        {
            _logSchemaRepository = new LogSchemaRepository(databaseContext, logSettings, iHttpContextAccessor);
        }

        public bool DropTables()
        {
            return _logSchemaRepository.DropTables();
        }

        public bool EnsureCreated()
        {
            return _logSchemaRepository.EnsureCreated();
        }
    }

}
