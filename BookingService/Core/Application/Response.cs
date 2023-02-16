using Application.Errors;

namespace Application
{
    public abstract class Response
    {
        public bool Success { get; set; }
        public IEnumerable<ErrorResponse>? Message { get; set; }
        public int ErrorCode { get; set; }
    }
}