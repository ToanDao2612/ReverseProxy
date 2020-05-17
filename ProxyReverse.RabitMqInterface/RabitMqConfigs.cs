namespace ProxyReverse.RabitMqInterface
{
    public interface IRabitMqConfigs
    {
        string HostName { get; }
        string UserName { get; }
        string Password { get; }

        string QueueName {get;}
    }

    public static class QueueDefaults
    {
        public static string TunelRequestQueue = nameof(TunelRequestQueue);
    }

    public class RabitMqConfigs : IRabitMqConfigs
    {
        public string HostName { get => "proxyreverse.queue"; }
        public string UserName { get => "rabitmquser"; }
        public string Password { get => "Dev1234@"; }

        public string QueueName => QueueDefaults.TunelRequestQueue;
    }
}