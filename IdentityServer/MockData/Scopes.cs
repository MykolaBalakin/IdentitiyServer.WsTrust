using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdentityServer.MockData
{
    static class Scopes
    {
        public static IReadOnlyCollection<Scope> Get()
        {
            return new List<Scope>();
        }
    }
}