using ElectricVehicleM.Repositories.QuangNM;
using ElectricVehicleM.Repositories.QuangNM.ModelExtensions;
using ElectricVehicleM.Repositories.QuangNM.Models;

namespace ElectricVehicleM.Services.QuangNM
{
    public class PromotionsQuangNmService : IPromotionsQuangNmService
    {
        //private readonly PromotionsQuangNmRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PromotionsQuangNmService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<int> CreateAsync(PromotionsQuangNm promotion)
        {
            promotion.CreatedAt = DateTime.Now;
            return await _unitOfWork.PromotionsQuangNmRepository.CreateAsync(promotion);
        }

        public async Task<bool> DeleteAsync(int promotionId)
        {
            try
            {
                var promotion = await _unitOfWork.PromotionsQuangNmRepository.GetByIdAsync(promotionId);
                return await _unitOfWork.PromotionsQuangNmRepository.RemoveAsync(promotion);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<PromotionsQuangNm>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.PromotionsQuangNmRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving promotions: {ex.Message}");
            }
        }

        public Task<PromotionsQuangNm> GetByIdAsync(int promotionId)
        {
            return _unitOfWork.PromotionsQuangNmRepository.GetByIdAsync(promotionId);
        }

        public Task<List<PromotionsQuangNm>> SearchAsync(string title, int maxUsage, string customerName)
        {
            return _unitOfWork.PromotionsQuangNmRepository.SearchAsync(title, maxUsage, customerName);
        }
        public async Task<PaginationResult<List<PromotionsQuangNm>>> SearchPagingAsync(PromotionsQuangNmSearchRequest searchRequest)
        {
            return await _unitOfWork.PromotionsQuangNmRepository.SearchPagingAsync(searchRequest);
        }

        public async Task<int> UpdateAsync(PromotionsQuangNm promotion)
        {
            return await _unitOfWork.PromotionsQuangNmRepository.UpdateAsync(promotion);
        }
    }
}
