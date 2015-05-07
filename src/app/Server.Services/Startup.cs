using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Cors;
using System.Web.Cors;
using System.Web.Http.Cors;
using System.Threading;

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
