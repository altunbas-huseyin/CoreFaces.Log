using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.Models.Domain
{
    public class Log : EntityBase
    {
        public Guid LogCategoryId { get; set; }
        public string TableName { get; set; } = "";
        public string TableRef { get; set; } = "";
        public string TransactionId { get; set; } = "";
        public string SessionId { get; set; } = "";
        public string UserId { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string ExceptionMessage { get; set; } = "";
        public string ExceptionType { get; set; } = "";
        public string ExceptionSource { get; set; } = "";
        public string ExceptionUrl { get; set; } = "";

    }
}
