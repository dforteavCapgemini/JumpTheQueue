﻿using Devon4Net.Application.WebAPI;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Service;
using Devon4Net.WebAPI.Implementation.Domain.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Devon4Net.Test.JumTheQueue
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Startup>
    {
        public IConfigurationRoot Configuration { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("integrationsettings.json")
               .Build();

                config.AddConfiguration(Configuration);
            });


            

            // will be called after the `ConfigureServices` from the Startup
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IJumpTheQueueService, JumpTheQueueService>();
            });
        }
    }
}
