using System.Collections.Generic;

namespace WebApp.Models.Response
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
        public IEnumerable<T> DataSet { get; set; }
        public Response(bool success, T data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }
        public Response(bool success, IEnumerable<T> dataset, string message)
        {
            Success = success;
            DataSet = dataset;
            Message = message;
        }
    }
}
