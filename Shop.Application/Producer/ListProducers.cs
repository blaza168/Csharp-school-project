using System.Collections.Generic;
using Shop.Application.Producer.ViewModels;
using Shop.Database.Repositories;

namespace Shop.Application.Producer
{
    [Service]
    public class ListProducers
    {
        private readonly ProducerRepository _producerRepository;

        public ListProducers(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public IEnumerable<ProducerViewModel> Do()
        {
            return _producerRepository.GetProducers(selector: GetProducer.ProducerMapper);
        }
    }
}