using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Log.Models.Domain
{
    public class LogCategory : EntityBase
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
