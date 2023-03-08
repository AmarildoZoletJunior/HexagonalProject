
using Application.Error;

namespace Application
{
    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<ErrorResponse> ListErrors { get; set; }
    }
}