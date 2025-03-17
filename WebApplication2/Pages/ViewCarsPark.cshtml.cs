using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class ViewCarsParkModel : PageModel
    {
        private readonly CarInfoService _carInfoService;
        public List<CarInfo> CarsInfo { get; set; } = new();
        [BindProperty(SupportsGet =true)]
        public string SearchString { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "Brand";
        public ViewCarsParkModel(CarInfoService carInfoService)
        {
            _carInfoService = carInfoService;
        }
        public void OnGet()
        {
            var carsinfo = _carInfoService.LoadCarInfo();
            if (!string.IsNullOrEmpty(SearchString))
            {
                carsinfo = carsinfo.Where(c => c.Brand.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                c.Model.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                c.Release.Contains(SearchString) ||
                c.Power.Contains(SearchString) ||
                c.NumberPlate.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                c.Cost.Contains(SearchString)||
                c.Id.ToString().Contains(SearchString)).ToList();
            }
            carsinfo = SortOrder switch
            {
                "ID_desc" => carsinfo.OrderByDescending(c => c.Id).ToList(),
                "ID" => carsinfo.OrderBy(c => c.Id).ToList(),
                "Brand_desc" => carsinfo.OrderByDescending(c => c.Brand).ToList(),
                "Model" => carsinfo.OrderBy(c => c.Model).ToList(),
                "Model_desc" => carsinfo.OrderByDescending(c => c.Model).ToList(),
                "Release_desc" => carsinfo.OrderByDescending(c => c.Release).ToList(),
                "Release" => carsinfo.OrderBy(c => c.Release).ToList(),
                "Power" => carsinfo.OrderBy(c => c.Power).ToList(),
                "Power_desc" => carsinfo.OrderByDescending(c => c.Power).ToList(),
                "NumberPlate_desc" => carsinfo.OrderByDescending(c => c.NumberPlate).ToList(),
                "NumberPlate" => carsinfo.OrderBy(c => c.NumberPlate).ToList(),
                "Cost_desc" => carsinfo.OrderByDescending(c => c.Cost).ToList(),
                "Cost" => carsinfo.OrderBy(c => c.Cost).ToList(),
                _ => carsinfo.OrderBy(c => c.Brand).ToList(),
            };
            CarsInfo = carsinfo;
        }
        public IActionResult OnPostDelete(int id)
        {
            _carInfoService.DeleteCarInfo(id);
            return RedirectToPage();
        }
    }
}
