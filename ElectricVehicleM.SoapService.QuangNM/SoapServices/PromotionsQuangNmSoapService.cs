using ElectricVehicleM.Services.QuangNM;
using ElectricVehicleM.SoapService.QuangNM.SoapModels;
using System.ServiceModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ElectricVehicleM.SoapService.QuangNM.SoapServices
{
    [ServiceContract]
    public interface IPromotionsQuangNmSoapService
    {
        /// Query
        [OperationContract]
        Task<List<PromotionsQuangNm>> GetAllAsync();
        [OperationContract]
        Task<PromotionsQuangNm> GetByIdAsync(int id);

        /// Mutation
        [OperationContract]
        Task<int> CreateAsync(PromotionsQuangNm promotion);
        [OperationContract]
        Task<int> UpdateAsync(PromotionsQuangNm promotion);
        [OperationContract]
        Task<int> DeleteAsync(int id);
    }

    public class PromotionsQuangNmSoapService : IPromotionsQuangNmSoapService
    {
        private readonly IServiceProviders _serviceProviders;

        public PromotionsQuangNmSoapService(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        public async Task<List<PromotionsQuangNm>> GetAllAsync()
        {
            try
            {
                // Handle circular references during JSON serialization
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                // Fetch all promotions from the service
                var promotions = await _serviceProviders.PromotionsQuangNmService.GetAllAsync();
                // Serialize to JSON string to handle circular references
                var promotionJsonString = JsonSerializer.Serialize(promotions, opt);

                var result = JsonSerializer.Deserialize<List<PromotionsQuangNm>>(promotionJsonString);

                return result;

            }
            catch
            {
                throw new Exception("Error occurred while fetching all promotions.");
            }
        }

        public async Task<PromotionsQuangNm> GetByIdAsync(int id)
        {
            try
            {
                // Get data from service
                var promotion = await _serviceProviders.PromotionsQuangNmService.GetByIdAsync(id);
                // Serialize with options to handle reference loops and ignore nulls
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                // Convert to JSON string
                var promotionJson = JsonSerializer.Serialize(promotion, opt);
                // Deserialize JSON string to PromotionsQuangNm
                var result = JsonSerializer.Deserialize<PromotionsQuangNm>(promotionJson, opt);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while fetching promotion with ID {id}: {ex.Message}");
            }
        }

        public async Task<int> CreateAsync(PromotionsQuangNm promotionInput)
        {
            try
            {
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                // Convert proto request to JSON string
                var promotion = JsonSerializer.Serialize(promotionInput, opt);
                var item = JsonSerializer.Deserialize<Repositories.QuangNM.Models.PromotionsQuangNm>(promotion);
                var result = await _serviceProviders.PromotionsQuangNmService.CreateAsync(item);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while creating promotion: {ex.Message}");
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                // Get data from service
                var result = await _serviceProviders.PromotionsQuangNmService.DeleteAsync(id);
                // Return 1 for success, 0 for failure
                return result ? 1 : 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting promotion with ID {id}: {ex.Message}");
            }
        }

        public async Task<int> UpdateAsync(PromotionsQuangNm promotionInput)
        {
            try
            {
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                // Convert proto request to JSON string
                var promotion = JsonSerializer.Serialize(promotionInput, opt);
                var item = JsonSerializer.Deserialize<Repositories.QuangNM.Models.PromotionsQuangNm>(promotion);
                var result = await _serviceProviders.PromotionsQuangNmService.UpdateAsync(item);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating promotion: {ex.Message}");
            }
        }
    }
}
