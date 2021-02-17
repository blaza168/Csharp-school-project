using NUnit.Framework;
using Shop.Application.Producer.Requests;
using Shop.Application.Util;
using Shop.Domain.Models;

namespace Shop.Tests.Application
{
    public class CopyUtilTest
    {
        [Test]
        public void CopyObjectAttributes()
        {
            int requestId = 1;
            string requestCountry = "SK";
            string requestName = "NewName";
            
            
            UpdateProducerRequest request = new UpdateProducerRequest
            {
                Id = requestId,
                Country = requestCountry,
                Name = requestName,
            };

            Producer producer = CopyUtil.CopyAttributes<UpdateProducerRequest, Producer>(request);
            
            Assert.AreEqual(requestId, producer.Id);
            Assert.AreEqual(requestCountry, producer.Country);
            Assert.AreEqual(requestName, producer.Name);
            
            Assert.IsNull(producer.File);
            Assert.IsNull(producer.Products);
            Assert.IsNull(producer.FileId);
        }

        [Test]
        public void CopyAttrobutesToInstance()
        {
            int producerId = 1;
            string producerCountry = "BL";
            string producerName = "Blem";
            
            int requestId = 1;
            string requestCountry = "SK";


            UpdateProducerRequest request = new UpdateProducerRequest
            {
                Id = requestId,
                Country = requestCountry
            };
            Producer producer = new Producer
            {
                Id = producerId,
                Country = producerCountry,
                Name = producerName,
            };
            
            CopyUtil.CopyAttributesToInstance(request, producer);
            
            Assert.AreEqual(requestId, producer.Id);
            Assert.AreEqual(requestCountry, producer.Country);
            Assert.IsNull(producer.Name);
            
            Assert.IsNull(producer.File);
            Assert.IsNull(producer.Products);
            Assert.IsNull(producer.FileId);
        }
    }
}