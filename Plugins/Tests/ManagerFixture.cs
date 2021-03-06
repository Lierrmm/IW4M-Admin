﻿using IW4MAdmin.Application;
using IW4MAdmin.Application.Misc;
using SharedLibraryCore.Configuration;
using SharedLibraryCore.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ManagerFixture : IDisposable
    {
        public ApplicationManager Manager { get; private set; }

        public ManagerFixture()
        {
            string logFile = @"X:\IW4MAdmin\Plugins\Tests\bin\Debug\netcoreapp2.2\test_mp.log";

            File.WriteAllText(logFile, Environment.NewLine);

            Manager = null;

            var config = new ApplicationConfiguration
            {
                Servers = new[]
                {
                    new ServerConfiguration()
                    {
                        IPAddress = "127.0.0.1",
                        Password = "test",
                        Port = 28960,
                        RConParserVersion = "test",
                        EventParserVersion = "IW4x (v0.6.0)",
                        ManualLogPath = logFile
                    }
                },
                RConPollRate = int.MaxValue
            };

            Manager.ConfigHandler = new BaseConfigurationHandler<ApplicationConfiguration>("test");
            Manager.ConfigHandler.Set(config);
            Manager.AdditionalRConParsers.Add(new TestRconParser());

            Manager.Init().Wait();

            Task.Run(() => Manager.Start());
        }

        public void Dispose()
        {
            Manager.Stop();
        }
    }

    [CollectionDefinition("ManagerCollection")]
    public class ManagerCollection : ICollectionFixture<ManagerFixture>
    {

    }
}
