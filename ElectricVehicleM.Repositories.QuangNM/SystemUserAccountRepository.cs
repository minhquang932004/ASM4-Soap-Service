using ElectricVehicleM.Repositories.QuangNM.Basic;
using ElectricVehicleM.Repositories.QuangNM.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectricVehicleM.Repositories.QuangNM
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() => _context ??= new DBContext.FA25_PRN232_SE1717_G1_ElectricVehicleManagementContext();

        public SystemUserAccountRepository(DBContext.FA25_PRN232_SE1717_G1_ElectricVehicleManagementContext context) => _context = context;

        public async Task<SystemUserAccount> GetUserAccountAsync(string userName, string password)
        {
            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive == true);

            return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password && u.IsActive == true);
            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Phone == userName && u.Password == password && u.IsActive == true);
            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.EmployeeCode == userName && u.Password == password && u.IsActive == true);
            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
        }
    }
}
