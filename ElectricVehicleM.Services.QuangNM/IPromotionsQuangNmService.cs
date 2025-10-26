using ElectricVehicleM.Repositories.QuangNM.ModelExtensions;
using ElectricVehicleM.Repositories.QuangNM.Models;

namespace ElectricVehicleM.Services.QuangNM
{
    public interface IPromotionsQuangNmService
    {
        Task<List<PromotionsQuangNm>> GetAllAsync();
        Task<PromotionsQuangNm> GetByIdAsync(int promotionId);
        Task<List<PromotionsQuangNm>> SearchAsync(string title, int maxUsage, string customerName);
        Task<PaginationResult<List<PromotionsQuangNm>>> SearchPagingAsync(PromotionsQuangNmSearchRequest searchRequest);
        Task<int> CreateAsync(PromotionsQuangNm promotion);
        Task<int> UpdateAsync(PromotionsQuangNm promotion);
        Task<bool> DeleteAsync(int promotionId);
    }
}
