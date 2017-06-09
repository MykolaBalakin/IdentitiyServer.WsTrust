using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdentityServer.MockData
{
    static class Clients
    {
        public static IReadOnlyCollection<Client> Get()
        {
            return new List<Client>();
        }
    }
}