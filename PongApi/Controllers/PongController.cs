using Microsoft.AspNetCore.Mvc;

namespace PongApi.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using PongMessages.Commands;

    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class PongController : Controller
    {
        [HttpPost("")]
        public void Post(SendPong message)
        { 
            BusFactory.Current.Send(message);
        }
    }
}
