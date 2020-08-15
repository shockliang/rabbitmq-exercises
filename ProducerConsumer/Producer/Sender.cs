using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using(var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                var message = "Starting with .net core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);
                
                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine($"Send messages {message}");
            }

            Console.WriteLine("Press any key to exit sender app");
            Console.ReadLine();
        }
    }
}
