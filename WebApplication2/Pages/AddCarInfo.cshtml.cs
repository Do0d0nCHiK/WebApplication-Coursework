using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class AddCarInfoModel : PageModel
    {
        private readonly CarInfoService _carInfoService;
        [BindProperty]
        public string Brand { get; set; }
        [BindProperty]
        public string Model {  get; set; }
        [BindProperty]
        public string Release {  get; set; }
        [BindProperty]
        public string Power {  get; set; }
        [BindProperty]
        public string Cost { get; set; }
        [BindProperty]
        public string PlateNumber { get; set; }
        public AddCarInfoModel(CarInfoService carInfoService)
        {
            _carInfoService = carInfoService;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CarInfo crinf = new CarInfo
            {
                Brand = this.Brand,
                Model = this.Model,
                Release = this.Release,
                Power = this.Power,
                Cost = this.Cost,
                NumberPlate = PlateNumber,
            };
            _carInfoService.AddNewCarInfo(crinf);
            return RedirectToPage("./AddCarInfo");
        }
        public void OnGet()
        {
        }
    }
}
