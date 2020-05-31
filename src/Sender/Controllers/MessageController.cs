using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IBusControl _bus;
        
        public MessageController (IBusControl bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage (Message msg)
        {
            Uri uri = new Uri("rabbitmq://localhost/message-queue");
            var endPoint = await _bus.GetSendEndpoint(uri);

            await endPoint.Send(msg);

            return Ok (new {success = true, data = msg});
        }
    }
}