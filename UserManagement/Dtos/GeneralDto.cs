using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Dtos
{
    public class GeneralDto
    {
        public class Response
        {
            public object Data { get; set; }
            public bool Error { get; set; }
            public string Message { get; set; }
        }
    }
}