﻿using Microsoft.AspNetCore.Mvc;

namespace PingApi.Controllers
{
    using System;
    using Microsoft.AspNetCore.Cors;
    using PingMessages.Commands;

    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class PingController : Controller
    {
        [HttpGet("")]
        public object Get()
        {
            return new
            {
                PingConfiguration.NServiceBusLicensePath,
                PingConfiguration.RabbitMQConnectionString
            };
        }

        [HttpPost("")]
        public SendPing Post(SendPing message)
        {
            message.Relay = message.Relay ?? Guid.NewGuid().ToString();
            BusFactory.Current.Send(message);
            return message;
        }
    }
}
