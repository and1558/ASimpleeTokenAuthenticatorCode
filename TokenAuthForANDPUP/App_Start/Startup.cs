﻿using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using TokenAuthForANDPUP.Providers;
using TokenAuthForANDPUP;

[assembly: OwinStartup(typeof(TokenAuthForANDPUP.App_Start.Startup))]
namespace TokenAuthForANDPUP.App_Start
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthCustomeTokenProvider(), // We will create
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new OAuthCustomRefreshTokenProvider() // We will create
            };

            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

    }
}