namespace ShipManagement.API.Models
{
    public class ResultDTO <T>
    {
        public T? Data { get; set; }
        public int? Count { get; set; }
        public bool? Success { get; set; }
        public IEnumerable<string>? Messages { get; set; }
    }
}
