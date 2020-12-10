using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace KafKaProducer.Aggregator.Models.Response
{
    public class ProducerResult
    {
        public string ProduceStatus { get; set; }
        public object Message { get; set; }
        public string  Topic { get; set; }
        public Partition Partition { get; set; }
        public Offset Offset { get; set; } 
    }
}
