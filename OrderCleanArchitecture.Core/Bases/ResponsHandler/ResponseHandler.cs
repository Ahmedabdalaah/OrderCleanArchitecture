using OrderCleanArchitecture.Core.Bases.Responses;

namespace OrderCleanArchitecture.Core.Bases.ResponsHandler
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {

        }
        public Res<T> Deleted<T>()
        {
            return new Res<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }
        public Res<T> Success<T>(T entity, object Meta = null)
        {
            return new Res<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Added Successfully",
                Meta = Meta
            };
        }
        public Res<T> Unauthorized<T>()
        {
            return new Res<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "UnAuthorized"
            };
        }
        public Res<T> BadRequest<T>(string Message = null)
        {
            return new Res<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }

        public Res<T> NotFound<T>(string message = null)
        {
            return new Res<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }

        public Res<T> Created<T>(T entity, object Meta = null)
        {
            return new Res<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = Meta
            };
        }
    }
}
