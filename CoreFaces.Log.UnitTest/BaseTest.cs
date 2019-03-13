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

            DbContextOptionsBuilder<LogDatabaseContext> builderLog = new DbContextOptionsBuilder<LogDatabaseContext>();
            var connectionString = "server=localhost;userid=root;password=12345;database=Identity;";
            builderLog.UseMySql(connectionString);



            _logDatabaseContext = new LogDatabaseContext(builderLog.Options);

            LogSettings _logSettings = new LogSettings() { FileUploadFolderPath = "c:/" };
            IOptions<LogSettings> logOptions = Options.Create(_logSettings);
            IHttpContextAccessor iHttpContextAccessor = new HttpContextAccessor { HttpContext = new DefaultHttpContext() };

            _logCategoryService = new LogCategoryService(_logDatabaseContext, logOptions, iHttpContextAccessor);
            _logService = new LogService(_logDatabaseContext, logOptions, iHttpContextAccessor);
            _logSchemaService=new LogSchemaService(_logDatabaseContext, logOptions, iHttpContextAccessor);
        }
    }

}
