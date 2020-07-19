using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message =  null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }
               

        public int StatusCode { get; set; }

        public string  Message { get; set; }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "a bad request u have made",
                401 => "u r not authorized hahaha",
                404 => "resource is nott found... sorry!!!",
                500 => "this is a server error hahaha",
                _ => null
            };
        }
    }
}
