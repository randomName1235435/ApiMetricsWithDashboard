using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server.Abstractions;
using App.Metrics.Formatters.Ascii;
using Microsoft.Extensions.Hosting;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;

namespace ApiMetricsWithDashboard.Api
{
    public static class Program
    {
        public static IHost BuildHost(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                            .UseMetricsWebTracking()
                            .UseMetrics(options =>
                            {
                                options.EndpointOptions = endpointOptions =>
                                {
                                    endpointOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                                    endpointOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
                                    endpointOptions.MetricsEndpointEnabled = false;

                                };
                            })
                            .ConfigureWebHostDefaults(webBuilder =>
                            {
                                webBuilder.UseStartup<Startup>();
                            })
                        .Build();
        }

        public static void Main(string[] args) { BuildHost(args).Run(); }
        //MetricsAspNetTrackingWebHostBuilderExtensions.(




        //            .UseMetrics(options =>
        //            {
        //                options.EndpointOptions = endpointOptions =>
        //{
        //endpointOptions.Me

        //}
        //            }).


    }
}
