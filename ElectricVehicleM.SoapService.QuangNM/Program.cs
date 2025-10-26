using ElectricVehicleM.Services.QuangNM;
using ElectricVehicleM.SoapService.QuangNM.SoapServices;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
builder.Services.AddScoped<IPromotionsQuangNmSoapService, PromotionsQuangNmSoapService>();
builder.Services.AddScoped<IPromotionUsageQuangNmSoapService, PromotionUsageQuangNmSoapService>();
builder.Services.AddSoapCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSoapEndpoint<IPromotionsQuangNmSoapService>("/PromotionsQuangNmSoapService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<IPromotionUsageQuangNmSoapService>("/PromotionUsageQuangNmSoapService.asmx", new SoapEncoderOptions());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
