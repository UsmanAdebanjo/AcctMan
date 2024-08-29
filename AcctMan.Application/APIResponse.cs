using System.Net;

namespace AcctMan.Application
{
    public class APIResponse<T>
    {
        public T Data { get; set; } 
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public APIResponse(T data, string message, HttpStatusCode statusCode)
        {
            Data = data;
            Message = message;
            StatusCode = statusCode;    
        }

        public static APIResponse<T> Response(string message, T data, HttpStatusCode statusCode)
        {
            return new APIResponse<T>(data, message, statusCode);
        }
    }

}
