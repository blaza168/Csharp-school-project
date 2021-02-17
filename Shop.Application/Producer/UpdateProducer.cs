using System.Threading.Tasks;
using Shop.Application.Producer.Requests;
using Shop.Application.Util;
using Shop.Database.Repositories;

namespace Shop.Application.Producer
{
    [Service]
    public class UpdateProducer
    {
        private readonly ProducerRepository _producerRepository;

        public UpdateProducer(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public Task<int> Do(UpdateProducerRequest request)
        {
            Domain.Models.Producer producer = CopyUtil.CopyAttributes<UpdateProducerRequest, Domain.Models.Producer>(request);

            return _producerRepository.UpdateProducerPartial(producer);
        }
    }
}