namespace ElectricVehicleM.Repositories.QuangNM.ModelExtensions
{
    public class SearchRequest
    {
        public int? CurrentPage { get; set; }

        public int? PageSize { get; set; } = 10;
    }

    public class PromotionsQuangNmSearchRequest : SearchRequest
    {
        public string? Title { get; set; }

        public int? MaxUsage { get; set; }

        public string? CustomerName { get; set; }
    }
}
