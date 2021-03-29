using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Shop.Application.Producer.ViewModels;
using Shop.Database.Repositories;

namespace Shop.Application.Producer
{
    [Service]
    public class ListProducers
    {
        public static readonly Expression<Func<Domain.Models.Producer, ProducerViewModel>> ProducerMapper = p =>
            new ProducerViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Country = p.Country,
            };

        private readonly ProducerRepository _producerRepository;

        public ListProducers(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public IEnumerable<ProducerViewModel> Do()
        {
            return _producerRepository.GetProducers(selector: ProducerMapper);
        }
    }
}