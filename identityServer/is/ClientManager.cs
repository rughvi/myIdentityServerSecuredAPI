using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace identityServer.@is
{
    internal static class ClientManager
    {
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                    new Client
                    {
                         ClientName = "Client Application1",
                         ClientId = "t8agr5xKt4$3",
                         AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                         ClientSecrets = { new Secret("eb300de4-add9-42f4-a3ac-abd3c60f1919".Sha256()) },
                         AllowedScopes = new List<string> { "venkata.app.api.read", "venkata.app.api.write" }
                    },
                    new Client
                    {
                         ClientName = "Client Application2",
                         ClientId = "3X=nNv?Sgu$S",
                         AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                         ClientSecrets = { new Secret("1554db43-3015-47a8-a748-55bd76b6af48".Sha256()) },
                         AllowedScopes = { "venkata.app.api" }
                    }
            };
    }
}
