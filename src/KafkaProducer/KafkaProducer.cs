using Confluent.Kafka;
using KafKaProducer.Aggregator.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaProducer
{
    public class KafkaProducer
    { 
        public static async Task SendAsync(ProducerInfo producerInfo)
        {
            var topicName = producerInfo.TopicName; //Environment.GetEnvironmentVariable("TOPIC_NAME");
            var kafkaUrl = producerInfo.Address; //Environment.GetEnvironmentVariable("KAFKA_URL");

            var config = new ProducerConfig
            {
                BootstrapServers = kafkaUrl
            };

            // Create a producer that can be used to send messages to kafka that have no key and a value of type string 
            using var p = new ProducerBuilder<object, string>(config).Build();

            var i = 0;
            while (true)
            {
                // Construct the message to send (generic type must match what was used above when creating the producer)
                var message = new Message<object, string>
                {
                    Value = $"Message #{++i}"
                };

                // Send the message to our test topic in Kafka                
                var dr = await p.ProduceAsync(topicName, message);
                Console.WriteLine($"Produced message '{dr.Value}' to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}");

                Thread.Sleep(5000);
            }
        }
    }
}
