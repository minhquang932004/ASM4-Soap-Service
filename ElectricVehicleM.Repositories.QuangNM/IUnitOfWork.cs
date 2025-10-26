namespace ElectricVehicleM.Repositories.QuangNM
{
    public interface IUnitOfWork
    {
        PromotionsQuangNmRepository PromotionsQuangNmRepository { get; }
        PromotionUsageQuangNmRepository PromotionUsageQuangNmRepository { get; }
        SystemUserAccountRepository SystemUserAccountRepository { get; }


        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();
    }
}
