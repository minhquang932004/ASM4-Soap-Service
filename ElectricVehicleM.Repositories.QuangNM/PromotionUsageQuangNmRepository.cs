using ElectricVehicleM.Repositories.QuangNM.Basic;
using ElectricVehicleM.Repositories.QuangNM.DBContext;
using ElectricVehicleM.Repositories.QuangNM.Models;

namespace ElectricVehicleM.Repositories.QuangNM
{
    public class PromotionUsageQuangNmRepository : GenericRepository<PromotionUsageQuangNm>
    {
        public PromotionUsageQuangNmRepository() => _context ??= new FA25_PRN232_SE1717_G1_ElectricVehicleManagementContext();

        public PromotionUsageQuangNmRepository(FA25_PRN232_SE1717_G1_ElectricVehicleManagementContext context) => _context = context;

    }
}
