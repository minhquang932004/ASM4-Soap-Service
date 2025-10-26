using ServiceReference1;
using ServiceReference2;

Console.WriteLine("Hello, World!");

IPromotionsQuangNmSoapService soapClient1 = new PromotionsQuangNmSoapServiceClient(PromotionsQuangNmSoapServiceClient.EndpointConfiguration.BasicHttpBinding_IPromotionsQuangNmSoapService);
IPromotionUsageQuangNmSoapService soapClient2 = new PromotionUsageQuangNmSoapServiceClient(PromotionUsageQuangNmSoapServiceClient.EndpointConfiguration.BasicHttpBinding_IPromotionUsageQuangNmSoapService);

Console.WriteLine("----- Call GetAllAsync -----");
var promotions = await soapClient1.GetAllAsync();
if (promotions != null && promotions.Length > 0)
{
    foreach (var item in promotions)
    {
        Console.WriteLine($"Id: {item.PromotionQuangNmid} - Title: {item.Title} - UsageId: {item.UsageQuangNmid}");
    }
}

Console.WriteLine("----- Call GetByIdAsync -----");
Console.Write("Input PromotionQuangNmid to get detail: ");
var input = Console.ReadLine();
if (int.TryParse(input, out int promotionId))
{
    var promotionById = await soapClient1.GetByIdAsync(promotionId);
    if (promotionById != null)
    {
        Console.WriteLine($"Result= Id: {promotionById.PromotionQuangNmid} - Title: {promotionById.Title} - UsageId: {promotionById.UsageQuangNmid}");
    }
}

Console.WriteLine("----- Call CreateAsync -----");
// Show available UsageQuangNmid options
Console.WriteLine("Available UsageQuangNmid options:");
var usages = await soapClient2.GetAllAsync();
if (usages != null && usages.Length > 0)
{
    foreach (var usage in usages)
    {
        Console.WriteLine($"UsageQuangNmid: {usage.UsageQuangNmid} - Name: {usage.CustomerName}");
    }
}

Console.Write("Input PromotionQuangNmid: ");
var promoId = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Input Title: ");
var title = Console.ReadLine();
Console.Write("Input Description: ");
var description = Console.ReadLine();
Console.Write("Input DiscountRate: ");
var discountRate = decimal.Parse(Console.ReadLine() ?? "0");
Console.Write("Input StartDate (yyyy-MM-dd): ");
var startDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));
Console.Write("Input EndDate (yyyy-MM-dd): ");
var endDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));
Console.Write("Is Active? (true/false): ");
var isActive = bool.Parse(Console.ReadLine() ?? "true");
Console.Write("Input ApplicableModel: ");
var applicableModel = Console.ReadLine();
Console.Write("Input MaxUsage: ");
var maxUsage = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Choose UsageQuangNmid from above: ");
var usageQuangNmid = int.Parse(Console.ReadLine() ?? "0");

var createRequest = new ServiceReference1.PromotionsQuangNm
{
    PromotionQuangNmid = promoId,
    Title = title,
    Description = description,
    DiscountRate = discountRate,
    StartDate = startDate,
    EndDate = endDate,
    IsActive = isActive,
    ApplicableModel = applicableModel,
    MaxUsage = maxUsage,
    CreatedAt = DateTime.UtcNow,
    UsageQuangNmid = usageQuangNmid
};

var createResponse = await soapClient1.CreateAsync(createRequest);
Console.WriteLine($"CreateAsync result: {createResponse}");

Console.WriteLine("----- Call UpdateAsync -----");
Console.Write("Input PromotionQuangNmid to update: ");
var updateId = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Input new Title: ");
var newTitle = Console.ReadLine();
Console.Write("Input new Description: ");
var newDescription = Console.ReadLine();
Console.Write("Input new DiscountRate: ");
var newDiscountRate = decimal.Parse(Console.ReadLine() ?? "0");
Console.Write("Input new StartDate (yyyy-MM-dd): ");
var newStartDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));
Console.Write("Input new EndDate (yyyy-MM-dd): ");
var newEndDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));
Console.Write("Is Active? (true/false): ");
var newIsActive = bool.Parse(Console.ReadLine() ?? "true");
Console.Write("Input new ApplicableModel: ");
var newApplicableModel = Console.ReadLine();
Console.Write("Input new MaxUsage: ");
var newMaxUsage = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Input new UsageQuangNmid: ");
var newUsageQuangNmid = int.Parse(Console.ReadLine() ?? "0");

var updateRequest = new ServiceReference1.PromotionsQuangNm
{
    PromotionQuangNmid = updateId,
    Title = newTitle,
    Description = newDescription,
    DiscountRate = newDiscountRate,
    StartDate = newStartDate,
    EndDate = newEndDate,
    IsActive = newIsActive,
    ApplicableModel = newApplicableModel,
    MaxUsage = newMaxUsage,
    CreatedAt = DateTime.UtcNow,
    UsageQuangNmid = newUsageQuangNmid
};

var updateResponse = await soapClient1.UpdateAsync(updateRequest);
Console.WriteLine($"UpdateAsync result: {updateResponse}");

Console.WriteLine("----- Call DeleteAsync -----");
Console.Write("Input PromotionQuangNmid to delete: ");
var deleteId = int.Parse(Console.ReadLine() ?? "0");
var deleteResponse = await soapClient1.DeleteAsync(deleteId);
Console.WriteLine($"DeleteAsync result: {deleteResponse}");

Console.WriteLine("-----------------------------");
Console.WriteLine("----- The New List After Mutation -----");
var promotionsAfter = await soapClient1.GetAllAsync();
if (promotionsAfter != null && promotionsAfter.Length > 0)
{
    foreach (var item in promotionsAfter)
    {
        Console.WriteLine($"Id: {item.PromotionQuangNmid} - Title: {item.Title} - UsageId: {item.UsageQuangNmid}");
    }
}