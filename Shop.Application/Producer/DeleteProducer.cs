using System.Threading.Tasks;
using Shop.Database.Repositories;

namespace Shop.Application.Producer
{
    [Service]
    public class DeleteProducer
    {
        private readonly ProducerRepository _producerRepository;

        public DeleteProducer(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public Task<int> Do(int producerId)
        {
            return _producerRepository.DeleteProducer(producerId);
        }
    }
}