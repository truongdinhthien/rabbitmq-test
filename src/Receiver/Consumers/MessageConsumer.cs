using System;
using System.Threading.Tasks;
using MassTransit;
using Models;

namespace Receiver.Consumers
{
    public class MessageConsumer : IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            var data = context.Message;
            await Console.Out.WriteLineAsync($"This is message with id = {data.Id}, title = {data.Title} and content {data.Content}");
        }
    }
}