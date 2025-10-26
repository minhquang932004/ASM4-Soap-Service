namespace ElectricVehicleM.Services.QuangNM
{
    public class ServiceProviders : IServiceProviders
    {
        PromotionsQuangNmService _promotionsQuangNmService;
        PromotionUsageQuangNmService _promotionUsageQuangNmService;
        SystemUserAccountService _systemUserAccountService;

        public ServiceProviders() { }

        public IPromotionsQuangNmService PromotionsQuangNmService
        {
            get { return _promotionsQuangNmService ??= new PromotionsQuangNmService(); }
        }

        public PromotionUsageQuangNmService PromotionUsageQuangNmService
        {
            get { return _promotionUsageQuangNmService ??= new PromotionUsageQuangNmService(); }
        }

        public SystemUserAccountService SystemUserAccountService
        {
            get { return _systemUserAccountService ??= new SystemUserAccountService(); }
        }
    }
}
