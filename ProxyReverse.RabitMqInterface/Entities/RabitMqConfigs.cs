using ProxyReverse.RabitMqInterface.Entities;

namespace ProxyReverse.RabitMqInterface.Entities
{
    internal interface IQueueConfigs
    {
        string HostName { get; }
        string UserName { get; }
        string Password { get; }

        string QueueName {get;}
    }

    internal class RabitMqConfigs : IQueueConfigs
    {
        public string HostName { get => "proxyreverse.queue"; }
        public string UserName { get => "rabitmquser"; }
        public string Password { get => "Dev1234@"; }

        public string QueueName => QueueDefaults.TunelRequest;
    }
}