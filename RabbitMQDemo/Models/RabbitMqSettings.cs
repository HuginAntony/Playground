﻿using System.Collections;
using System.Collections.Generic;

namespace RabbitMQDemo
{
    public class RabbitMqSettings
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
        public IEnumerable<string> Queues { get; set; }
    }
}