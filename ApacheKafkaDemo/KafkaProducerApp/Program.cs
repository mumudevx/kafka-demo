using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .Build();

var bootstrapServers = config["Kafka:BootstrapServers"] ??
                       throw new Exception("BootstrapServers cannot read from appSettings.json");

var topic = config["Kafka:TopicName"] ??
            throw new Exception("TopicName cannot read from appSettings.json");

var producerConfig = new ProducerConfig
{
    BootstrapServers = bootstrapServers
};

Console.WriteLine("Enter messages to send Kafka (type 'exit' to quit):");

using var producer = new ProducerBuilder<Null, string>(producerConfig).Build();

string? message;

while ((message = Console.ReadLine()) != "exit")
{
    try
    {
        var deliveryResult = await producer
            .ProduceAsync(topic, new Message<Null, string> { Value = message });

        Console.WriteLine($"Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Error producing message: {exception.Message}");
        throw;
    }
}