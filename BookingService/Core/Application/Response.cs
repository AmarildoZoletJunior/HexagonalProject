namespace Application
{
    public abstract class Response
    {
        public bool Success { get; set; }
        public List<string> Message { get; set; }
        public int ErrorCode { get; set; }
    }
}