namespace ElectricVehicleM.Services.QuangNM
{
    public interface IServiceProviders
    {
        IPromotionsQuangNmService PromotionsQuangNmService { get; }
        PromotionUsageQuangNmService PromotionUsageQuangNmService { get; }
        SystemUserAccountService SystemUserAccountService { get; }
    }
}
