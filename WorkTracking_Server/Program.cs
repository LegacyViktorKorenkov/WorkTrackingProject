using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkTracking_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).UseWindowsService();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Debug);
                logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Debug);
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        #region ������������� IP �������
                        //options.ListenLocalhost(5000);
                        //options.Listen(IPAddress.Parse("10.130.37.28"), 5000);

                        //IPAddress[] iPAddresses = Dns.GetHostAddresses(Environment.MachineName);
                        //foreach (var ipAddress in iPAddresses)
                        //{
                        //    // ������ ���� v4 �������� � ��������� �������.
                        //    if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        //    {
                        //        options.Listen(ipAddress, 5000);
                        //    }
                        //}
                        #endregion

                        options.ListenAnyIP(5010);
                    })
                   .UseStartup<Startup>();

                }).UseWindowsService();
    }
}
