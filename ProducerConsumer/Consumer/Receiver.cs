using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    class Receiver
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using(var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, e) =>
                {
                    var body = e.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Receive message:{message}");
                };

                channel.BasicConsume("BasicTest", true, consumer);
                Console.WriteLine("Press any key to exit the consumer");
                Console.ReadLine();
            }

        }
    }
}
