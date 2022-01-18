namespace Calculator_RESTApiGateway.Models
{
    public class Reply
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public Result[] Results { get; set; }
    }
}
