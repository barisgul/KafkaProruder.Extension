using KafKaProducer.Aggregator.Models;
using Swashbuckle.AspNetCore.Filters;

namespace KafkaProducer.Api.Filters
{
    public class ProducerModelExample : IExamplesProvider<ProducerInfo>
    {
        public ProducerInfo GetExamples()
        {
            return new ProducerInfo
            {
                Address = "testAdres",
                Message = "testMessage",
                Port = 443,
                TopicName = "test-topic"
            };
        }
    }
}