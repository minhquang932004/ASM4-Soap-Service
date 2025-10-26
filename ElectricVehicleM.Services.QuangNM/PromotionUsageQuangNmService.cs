using ElectricVehicleM.Repositories.QuangNM;
using ElectricVehicleM.Repositories.QuangNM.Models;

namespace ElectricVehicleM.Services.QuangNM
{
    public class PromotionUsageQuangNmService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PromotionUsageQuangNmService() => _unitOfWork = new UnitOfWork();

        public async Task<List<PromotionUsageQuangNm>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.PromotionUsageQuangNmRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving promotion usages: {ex.Message}");
                return new List<PromotionUsageQuangNm>();
            }
        }
    }
}
