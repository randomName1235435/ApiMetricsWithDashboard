using Microsoft.AspNetCore.Hosting;
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
    }
}
