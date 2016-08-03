using Microsoft.AspNetCore.Mvc;

namespace PongApi.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using PongMessages.Commands;

    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class PongController : Controller
    {
        [HttpGet("")]
        public object Get()
        {
            return new
            {
                PongConfiguration.NServiceBusLicensePath,
                PongConfiguration.RabbitMQConnectionString 
            };
        }

        [HttpPost("")]
        public void Post(SendPong message)
        { 
            BusFactory.Current.Send(message);
        }
    }
}
