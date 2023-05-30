using Application.DTO;
using Application.DTO.Candidate;
using Application.DTO.Recruiter;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Application.Producers
{
    internal class RegisterProducer
    {
        private readonly IModel _channel;
        private readonly string _queue;

        internal RegisterProducer(string queue)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "register-service",
                Port = 5671,
                UserName = "guest",
                Password = "guest"
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _queue = queue;

            _channel.QueueDeclare(queue: _queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
        }


        internal void RegisterCandidate(CandidateUserServiceDTO dto)
        {
            byte[] messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto));

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(
               exchange: "",
               routingKey: _queue,
               basicProperties: properties,
               body: messageBody);

            _channel.Close();
        }

        internal void RegisterRecruiter(RecruiterUserServiceDTO dto)
        {
            byte[] messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto));

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(
               exchange: "",
               routingKey: _queue,
               basicProperties: properties,
               body: messageBody);

            _channel.Close();
        }

        internal void RegisterCredentials(CredentailsDTO dto)
        {
            byte[] messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto));

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(
               exchange: "",
               routingKey: _queue,
               basicProperties: properties,
               body: messageBody);

            _channel.Close();
        }
    }
}
