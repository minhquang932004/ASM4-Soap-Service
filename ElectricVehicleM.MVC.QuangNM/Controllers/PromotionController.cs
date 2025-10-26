using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceReference1;
using ServiceReference2;

namespace ElectricVehicleM.MVC.QuangNM.Controllers
{
    public class PromotionController : Controller
    {
        private readonly PromotionsQuangNmSoapServiceClient _soapClient;
        private readonly PromotionUsageQuangNmSoapServiceClient _usageClient;


        public PromotionController(PromotionsQuangNmSoapServiceClient soapClient, PromotionUsageQuangNmSoapServiceClient usageClient)
        {
            _soapClient = soapClient;
            _usageClient = usageClient;
        }

        // List
        public async Task<IActionResult> Index()
        {
            var result = await _soapClient.GetAllAsync();
            return View(result);
        }

        // Details
        public async Task<IActionResult> Details(int id)
        {
            var result = await _soapClient.GetByIdAsync(id);
            return View(result);
        }

        // Create (GET)
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Fetch UsageQuangNm list from SOAP service
            var usages = await _usageClient.GetAllAsync();
            ViewBag.UsageQuangNmidList = usages
                .Select(u => new SelectListItem
                {
                    Value = u.UsageQuangNmid.ToString(),
                    Text = $"{u.UsageQuangNmid} - {u.CustomerName}"
                })
                .ToList();

            return View();
        }

        // Create (POST)
        [HttpPost]
        public async Task<IActionResult> Create(ServiceReference1.PromotionsQuangNm model)
        {
            model.CreatedAt = DateTime.UtcNow;
            var response = await _soapClient.CreateAsync(model);
            if (response > 0)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Create failed");
            return View(model);
        }

        // Edit (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _soapClient.GetByIdAsync(id);
            return View(result);
        }

        // Edit (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(ServiceReference1.PromotionsQuangNm model)
        {
            model.CreatedAt = DateTime.UtcNow;
            var response = await _soapClient.UpdateAsync(model);
            if (response > 0)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Update failed");
            return View(model);
        }

        // Delete (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _soapClient.GetByIdAsync(id);
            return View(result);
        }

        // Delete (POST)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _soapClient.DeleteAsync(id);
            if (response > 0)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Delete failed");
            return RedirectToAction("Delete", new { id });
        }
    }
}
