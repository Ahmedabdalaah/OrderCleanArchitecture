using System.Net;

namespace OrderCleanArchitecture.Core.Bases.Responses
{
    public class Res<T>
    {
        public Res()
        {

        }
        public Res(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Res(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public Res(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
