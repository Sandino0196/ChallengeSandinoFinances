﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChallengeSandinoFinances.Startup))]

namespace ChallengeSandinoFinances
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
