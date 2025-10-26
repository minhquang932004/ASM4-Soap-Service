using ElectricVehicleM.Repositories.QuangNM.Basic;
using ElectricVehicleM.Repositories.QuangNM.DBContext;
using ElectricVehicleM.Repositories.QuangNM.ModelExtensions;
using ElectricVehicleM.Repositories.QuangNM.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectricVehicleM.Repositories.QuangNM
{
    public class PromotionsQuangNmRepository : GenericRepository<PromotionsQuangNm>
    {
        public PromotionsQuangNmRepository() => _context ??= new FA25_PRN232_SE1717_G1_ElectricVehicleManagementContext();

        public PromotionsQuangNmRepository(FA25_PRN232_SE1717_G1_ElectricVehicleManagementContext context) => _context = context;

        public async Task<List<PromotionsQuangNm>> GetAllAsync()
        {
            var promotions = await _context.PromotionsQuangNms.Include(d => d.UsageQuangNm).ToListAsync();

            return promotions ?? new List<PromotionsQuangNm>();
        }

        public async Task<PromotionsQuangNm> GetByIdAsync(int id)
        {
            var promotion = await _context.PromotionsQuangNms.Include(d => d.UsageQuangNm).FirstOrDefaultAsync(d => d.PromotionQuangNmid == id);
            return promotion ?? new PromotionsQuangNm();
        }

        public async Task<List<PromotionsQuangNm>> SearchAsync(string title, int maxUsage, string customerName)
        {
            var promotions = await _context.PromotionsQuangNms
                .Include(d => d.UsageQuangNm)
                .Where(d => (d.Title.Contains(title) || string.IsNullOrEmpty(title))
                && (d.MaxUsage == maxUsage || maxUsage == 0 || maxUsage == null)
                && (d.UsageQuangNm.CustomerName.Contains(customerName) || string.IsNullOrEmpty(customerName))
                )
                .OrderBy(d => d.PromotionQuangNmid).ToListAsync();
            return promotions ?? new List<PromotionsQuangNm>();
        }

        public async Task<PaginationResult<List<PromotionsQuangNm>>> SearchPagingAsync(PromotionsQuangNmSearchRequest searchRequest)
        {
            var promotions = await this.SearchAsync(searchRequest.Title, searchRequest.MaxUsage.Value, searchRequest.CustomerName);
            var totalItems = promotions.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / searchRequest.PageSize.Value);

            promotions = promotions.Skip((searchRequest.CurrentPage.Value - 1) * searchRequest.PageSize.Value).Take(searchRequest.PageSize.Value).ToList();

            var result = new PaginationResult<List<PromotionsQuangNm>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = searchRequest.CurrentPage.Value,
                PageSize = searchRequest.PageSize.Value,
                Items = promotions
            };

            return result ?? new PaginationResult<List<PromotionsQuangNm>>();
        }
    }
}
