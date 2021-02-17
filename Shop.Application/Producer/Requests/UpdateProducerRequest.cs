namespace Shop.Application.Producer.Requests
{
    public class UpdateProducerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
    }
}