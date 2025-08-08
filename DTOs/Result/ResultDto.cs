using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Result
{
    public class ResultDto
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public static ResultDto SuccessResult(object data = null, string message = "Operación exitosa", int statusCode = 200)
        {
            return new ResultDto
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static ResultDto FailResult(string message = "Error", int statusCode = 400)
        {
            return new ResultDto
            {
                Success = false,
                Data = null,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}
