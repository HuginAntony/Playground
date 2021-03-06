﻿using Microsoft.Owin.Security.Cookies;
using Owin;
using OwinSelfHostWebApi.Configurations;

namespace OwinSelfHostWebApi
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder app)
        {
            app.UseDebugMiddleware(DebugMiddlewareExtensions.GetDefaultOptions());

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new Microsoft.Owin.PathString("/Auth/Login")
            });
            // Configure Web API for self-host. 
            app.UseWebApi(WebConfig.GetHttpConfiguration());
        }
    }
}
