using Confluent.Kafka;
using KafKaProducer.Aggregator.Models;
using KafKaProducer.Aggregator.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaProducer
{
    public static class KafkaProducer
    {
        static List<ProducerResult> results;
        static KafkaProducer()
        {
            results = new List<ProducerResult>();
        }
        public static void Produce(ProducerInfo producerInfo, out List<ProducerResult> producerResults)
        {
            SendAsync(producerInfo);
            producerResults = results; 
        }

        private static async Task SendAsync(ProducerInfo producerInfo)
        {
            List<ProducerResult>  producerResults = new List<ProducerResult>();
            string topicName = producerInfo.TopicName; //Environment.GetEnvironmentVariable("TOPIC_NAME");
            string port = producerInfo.Port.ToString();
            string address = producerInfo.Address;
            var kafkaUrl = address+"/"+port; //Environment.GetEnvironmentVariable("KAFKA_URL");

            var config = new ProducerConfig
            {
                BootstrapServers = kafkaUrl
            };

            // Create a producer that can be used to send messages to kafka that have no key and a value of type string 
            using var p = new ProducerBuilder<object, object>(config).Build();

            var i = 0;
            while (true)
            {
                // Construct the message to send (generic type must match what was used above when creating the producer)
                var message = new Message<object, object>
                {
                    Value = $"Message #{++i}"
                };

                // Send the message to our test topic in Kafka                
                var dr = await p.ProduceAsync(topicName, message);
                Console.WriteLine($"Produced message '{dr.Value}' to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}");

                results.Add(new ProducerResult
                {
                    Message = dr.Value,
                    Topic = dr.Topic,
                    Partition = dr.Partition,
                    Offset = dr.Offset,
                    ProduceStatus = "Produced"
                });

                Thread.Sleep(TimeSpan.FromMilliseconds(5000));
            } 
        }
    }
}
