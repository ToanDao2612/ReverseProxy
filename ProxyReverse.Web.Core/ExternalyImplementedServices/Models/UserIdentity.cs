using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Web.Core.ExternalyImplementedServices.Models
{
    public class UserIdentity
    {
        public UserIdentity(int userId)
        {
            UserId = userId;
        }

        public int UserId {get;}
    }
}
