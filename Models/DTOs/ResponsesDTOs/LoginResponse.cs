using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.ResponsesDTOs
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            ErrorMessage = string.Empty;
        }
        public bool Success => string.IsNullOrEmpty(ErrorMessage) && string.IsNullOrWhiteSpace(ErrorMessage);
        public string ErrorMessage { get; set; }
        public string Token {  get; set; }  
    }
}
