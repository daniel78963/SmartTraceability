using System;
using System.Collections.Generic;
using System.Text;

namespace SmartTraceability.Model.Data.Dto
{
    public class ReadTaskResponse
    {
        private readonly string message;

        public ReadTaskResponse(string msg)
        {
            this.message = msg;
        }

        public string Message { get { return message; } }
    }
}
