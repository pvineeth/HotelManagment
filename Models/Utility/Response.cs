using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Models.Utility
{
    public class Response
    {
        public Response() 
        {
            ErrorMessage = string.Empty;
        }
        public bool Success =>string.IsNullOrEmpty(ErrorMessage)&& string.IsNullOrWhiteSpace(ErrorMessage);
        public string ErrorMessage {  get; set; }
    }
}
