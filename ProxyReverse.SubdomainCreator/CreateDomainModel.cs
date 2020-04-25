namespace ProxyReverse.SubdomainCreator
{
    public class CreateDomainModel
    {
        public string Domain { get; set; }
        public string DomainAuthorizationKey { get; set; }
        public string Ip { get; set; }
        public string SubdomainName { get; set; }
        public int RefresRate { get; set; }
        public string Type { get; set; }
    }
}