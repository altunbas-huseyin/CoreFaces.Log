using CoreFaces.Log.Models.Models;
using CoreFaces.Log.Repositories;
using CoreFaces.Log.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.UnitTest
{
    public class BaseTest
    {
        public LogDatabaseContext _logDatabaseContext;
        public readonly ILogCategoryService _logCategoryService;
        public readonly ILogService _logService;
        public readonly ILogSchemaService _logSchemaService;


        public BaseTest()
        {

            DbContextOptionsBuilder<LogDatabaseContext> builder = new DbContextOptionsBuilder<LogDatabaseContext>();
            var connectionString = "server=localhost;userid=root;password=12345;database=Identity;";
            builder.UseMySql(connectionString);


            _logDatabaseContext = new LogDatabaseContext(builder.Options);

            LogSettings _statusSettings = new LogSettings() { FileUploadFolderPath = "c:/" };
            IOptions<LogSettings> statusOptions = Options.Create(_statusSettings);
            IHttpContextAccessor iHttpContextAccessor = new HttpContextAccessor { HttpContext = new DefaultHttpContext() };

            _logCategoryService = new LogCategoryService(_logDatabaseContext, statusOptions, iHttpContextAccessor);
            _logService = new LogService(_logDatabaseContext, statusOptions, iHttpContextAccessor);
            _logSchemaService=new LogSchemaService(_logDatabaseContext, statusOptions, iHttpContextAccessor);
        }
    }

}
