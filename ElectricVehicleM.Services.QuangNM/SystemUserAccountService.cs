using ElectricVehicleM.Repositories.QuangNM;
using ElectricVehicleM.Repositories.QuangNM.Models;

namespace ElectricVehicleM.Services.QuangNM
{
    public class SystemUserAccountService
    {
        private readonly UnitOfWork _unitOfWork;

        public SystemUserAccountService() => _unitOfWork ??= new UnitOfWork();

        public async Task<SystemUserAccount> GetUserAccount(string email, string password)
        {
            try
            {
                return await _unitOfWork.SystemUserAccountRepository.GetUserAccountAsync(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the user account: {ex.Message}");
                return null;
            }
        }
    }
}
