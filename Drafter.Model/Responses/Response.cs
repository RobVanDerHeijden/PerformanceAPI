namespace Drafter.Model.Responses
{
    public abstract class Response<T>
    {
        public bool Succes { get; set; }
        public string Message { get; set; }
        public T Entity { get; set; }

        public Response(T entity)
        {
            Succes = true;
            Message = string.Empty;
            Entity = entity;
        }

        public Response(string message)
        {
            Succes = false;
            Message = message;
            Entity = default;
        }
    }
}