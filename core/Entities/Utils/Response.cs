namespace core.Entities.Utils
{
    public class Response<T>
    {
        public string message { get; set; }
        public string status { get; set; }
        public List<T>? data { get; set; }
    }
}
