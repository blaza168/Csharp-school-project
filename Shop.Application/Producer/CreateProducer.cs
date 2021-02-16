using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Application.Producer.Requests;
using Shop.Database.Repositories;

namespace Shop.Application.Producer
{
    [Service]
    public class CreateProducer
    {
        private readonly ProducerRepository _producerRepository;

        public CreateProducer(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public Task<int> Do(CreateProducerRequest request)
        {
            return _producerRepository.CreateProducer(new Domain.Models.Producer
            {
                Name = request.Name,
                Description = request.Description,
                Country = request.Country,
            });
        }
    }
}