using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyReverse.Web.Core.InternalyImplementedServices
{
    public interface IUserUrlProvider
    {
        string GetUrlForUser();
    }

    public class UserUrlProvider : IUserUrlProvider
    {
        public string GetUrlForUser() => RandomString(10);

        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static string RandomString(int length)
            =>
            new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
