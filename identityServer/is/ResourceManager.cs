using System;
using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace identityServer.@is
{
    internal static class ResourceManager
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "Neon Roles", new List<string>() { JwtClaimTypes.Role })
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource {
                    Name = "venkata.app.api",
                    DisplayName = "Venkata Apis",
                    ApiSecrets = { new Secret("a75a559d-1dab-4c65-9bc0-f8e590cb388d".Sha256()) },                    
                    Scopes = new List<string> {
                        "venkata.app.api.read",
                        "venkata.app.api.write",
                        "venkata.app.api.full"
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope {
                    Name = "venkata.app.api.read",
                    DisplayName = "API Read",
                    UserClaims = new List<string>() { "venkata.app.api.read", JwtClaimTypes.Role }
                },

                new ApiScope {
                    Name = "venkata.app.api.write",
                    DisplayName = "API Write",
                    UserClaims = new List<string>() { "venkata.app.api.write", JwtClaimTypes.Role }
                },

                new ApiScope {
                    Name = "venkata.app.api.full",
                    DisplayName = "API Full",
                    UserClaims = new List<string>() { "venkata.app.api.full", JwtClaimTypes.Role }
                }
            };
    }
}
