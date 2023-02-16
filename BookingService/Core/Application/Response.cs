using Application.Errors;

namespace Application
{
    public abstract class Response
    {
        public bool Success { get; set; }
        public List<ErrorResponse>? ListMessages { get; set; }
        public string Message { get; set; }
    }
}