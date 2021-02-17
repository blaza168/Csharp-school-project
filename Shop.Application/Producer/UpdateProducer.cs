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
            // Domain.Models.Producer producer = _producerRepository.GetProducerById(request.Id, p => new Domain.Models.Producer
            // {
            //     Id = p.Id,
            //     Description = p.Description,
            //     Name = p.Name,
            //     Country = p.Country,
            // });
            //
            // if (producer == null)
            // {
            //     return Task.FromResult(0);
            // }
            
            // CopyUtil.CopyAttributesToInstance(request, producer);
            //
            // return _producerRepository.UpdateProducer(producer);

            Domain.Models.Producer producer = CopyUtil.CopyAttributes<UpdateProducerRequest, Domain.Models.Producer>(request);

            return _producerRepository.UpdateProducerPartial(producer);
        }
    }
}