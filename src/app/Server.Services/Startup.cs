﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Server.Services.Startup))]

namespace Server.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
