using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .Build();

var bootstrapServers = config["Kafka:BootstrapServers"];
var topic = config["Kafka:TopicName"];

var consumerConfig = new ConsumerConfig
{
    BootstrapServers = bootstrapServers,
    GroupId = "kafka-demo-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

consumer.Subscribe(topic);
Console.WriteLine("Consuming messages... (press Ctrl+C to quit)");

try
{
    while (true)
    {
        var consumeResult = consumer.Consume();
        Console.WriteLine($"Received message: {consumeResult.Message.Value}");
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine("Closing consumer.");
    consumer.Close();
}