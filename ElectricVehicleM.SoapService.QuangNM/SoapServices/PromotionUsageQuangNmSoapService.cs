using ElectricVehicleM.Services.QuangNM;
using ElectricVehicleM.SoapService.QuangNM.SoapModels;
using System.ServiceModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ElectricVehicleM.SoapService.QuangNM.SoapServices
{
    [ServiceContract]
    public interface IPromotionUsageQuangNmSoapService
    {
        /// Query
        [OperationContract]
        Task<List<PromotionUsageQuangNm>> GetAllAsync();
    }

    public class PromotionUsageQuangNmSoapService : IPromotionUsageQuangNmSoapService
    {
        private readonly IServiceProviders _serviceProviders;
        public PromotionUsageQuangNmSoapService(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }
        public async Task<List<PromotionUsageQuangNm>> GetAllAsync()
        {
            try
            {
                // Handle circular references during JSON serialization
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
                // Fetch all promotions from the service
                var promotions = await _serviceProviders.PromotionUsageQuangNmService.GetAllAsync();
                // Serialize to JSON string to handle circular references
                var promotionUsageJsonString = JsonSerializer.Serialize(promotions, opt);

                var result = JsonSerializer.Deserialize<List<PromotionUsageQuangNm>>(promotionUsageJsonString);

                return result;

            }
            catch
            {
                throw new Exception("Error occurred while fetching all promotionUsages.");
            }
        }
    }
}
