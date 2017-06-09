using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.WsFederation.Models;

namespace IdentityServer.MockData
{
    static class RelyingParties
    {
        public static IReadOnlyCollection<RelyingParty> Get()
        {
            return new List<RelyingParty>
            {
                new RelyingParty
                {
                    Realm = "urn:owinrp",
                    Enabled = true,
                    ReplyUrl = "https://srv1.balakin.local",
                    TokenType = "urn:oasis:names:tc:SAML:2.0:assertion",
                    TokenLifeTime = (int) TimeSpan.FromDays(7).TotalMinutes,
                    Name = "LocalSTS",
                    ClaimMappings = new Dictionary<string, string>
                    {
                        { Constants.ClaimTypes.Name, ClaimTypes.Name },
                        { Constants.ClaimTypes.GivenName, ClaimTypes.GivenName },
                        { Constants.ClaimTypes.FamilyName, ClaimTypes.Surname },
                        { Constants.ClaimTypes.Email, ClaimTypes.Email }
                    }
                }
            };
        }
    }
}