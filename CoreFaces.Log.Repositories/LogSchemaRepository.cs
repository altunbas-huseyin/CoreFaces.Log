using CoreFaces.Licensing;
using CoreFaces.Log.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CoreFaces.Log.Repositories
{
    public interface ILogSchemaRepository
    {
        bool DropTables();
        bool EnsureCreated();
    }

    public class LogSchemaRepository : Licence, ILogSchemaRepository
    {
        private readonly LogDatabaseContext _identityDatabaseContext;

        public LogSchemaRepository(LogDatabaseContext identityDatabaseContext, IOptions<LogSettings> logSettings, IHttpContextAccessor iHttpContextAccessor) : base("Log", iHttpContextAccessor, logSettings.Value.LogLicenseDomain, logSettings.Value.LogLicenseKey)
        {
            _identityDatabaseContext = identityDatabaseContext;
        }

        public bool DropTables()
        {
            int result = _identityDatabaseContext.Database.ExecuteSqlCommand("DROP TABLE Log; DROP TABLE LogCategory;");
            if (result == 0)
                return true;
            else
                return false;
        }

        public bool EnsureCreated()
        {
            RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)_identityDatabaseContext.Database.GetService<IDatabaseCreator>();
            databaseCreator.CreateTables();
            return true;
        }
    }

}
