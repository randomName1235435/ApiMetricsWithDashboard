using App.Metrics.Counter;

namespace ApiMetricsWithDashboard.Api.Metrics
{
    public class MetricsRegistry
    {
        public static CounterOptions CreatedCustomerCounter => new CounterOptions
        {
            Name = "Created Customer Count",
            Context = "CustomerApi",
            MeasurementUnit = App.Metrics.Unit.Items,
        };

    }
}
