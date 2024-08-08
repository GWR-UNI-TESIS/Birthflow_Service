using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Application.DTOs
{
    public class BaseResponse<T> where T : class
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Response { get; set; }
        public BaseResponse() { }

        public BaseResponse(int statusCode, string message, T data = default)
        {
            StatusCode = statusCode;
            Message = message;
            Response = data;
        }

        public static BaseResponse<T> Succes(string message, T data = default)
        {
            return new BaseResponse<T>(StatusCodes.Status200OK, message, data);
        }
        public static BaseResponse<T> Error(int statusCode, string message)
        {
            return new BaseResponse<T>(statusCode, message);
        }
        public static BaseResponse<T> Error(string message)
        {
            return new BaseResponse<T>(StatusCodes.Status500InternalServerError, message);
        }
        public static BaseResponse<T> NotFound(string message)
        {
            return new BaseResponse<T>(StatusCodes.Status404NotFound, message);
        }
        public static BaseResponse<T> Created(string message, T data)
        {
            return new BaseResponse<T>(StatusCodes.Status201Created, message, data);
        }
        public static BaseResponse<T> NoContent(string message)
        {
            return new BaseResponse<T>(StatusCodes.Status204NoContent, message);
        }
    }
}
