namespace Shop.Application.Producer.Requests
{
    public class CreateProducerRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public int? FileId { get; set; }
    }
}