namespace KafKaProducer.Aggregator.Models
{
    public class ProducerInfo
    {
        public string TopicName { get; set; }
        public string Address { get; set; }
        public long Port { get; set; }
        public string Message { get; set; } 
    }
}
