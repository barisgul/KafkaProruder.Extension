using CommandLine; 

namespace KafkaProducer.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Verbose)
                       {
                           System.Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           System.Console.WriteLine($"Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           System.Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           System.Console.WriteLine("Quick Start Example!");
                       }
                   });
        }
    }
}
