namespace Manlika_WebApi.Model
{
    public class Currency
    {
        public string? url { get; set; }
        public string? method { get; set; }
        public CurrencyResponseData? response { get; set; }

    }

    public class CurrencyResponseData
    {
        public string? table { get; set; }
        public string? currency { get; set; }
        public string? code { get; set; }
        public List<RateResponseData>? rates { get; set; }
    }

    public class RateResponseData
    {
        public string? no { get; set; }
        public string? effectiveDate { get; set; }
        public decimal? bid { get; set; }
        public decimal? ask { get; set; }
    }
}
