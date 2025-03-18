using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class AddRentInfoModel : PageModel
    {
        private readonly RentInfoService _rentInfoService;
        [BindProperty]
        public DateTime _date { get; set; } = DateTime.Now.Date;
        [BindProperty]
        public string ClientID { get; set; }
        [BindProperty]
        public string CarID { get; set; }
        [BindProperty]
        public string Period { get; set; }
        private string StartDate { get; set; }
        private string EndDate { get; set; }

        public AddRentInfoModel(RentInfoService rentInfoService)
        {
            _rentInfoService = rentInfoService;
        }
        public IActionResult OnPost()
        {
            if (_date.Year < 2010 || _date.Year > 2026) ModelState["_date"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            StartDate = _date.ToShortDateString();
            EndDate = _date.AddDays(int.Parse(Period)).ToShortDateString();
            RentInfo rentinf = new RentInfo
            {
                ClientID = this.ClientID,
                CarID = this.CarID,
                Period = this.Period,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
            };
            _rentInfoService.AddNewRentInfo(rentinf);
            return RedirectToPage("Main");
        }
        public void OnGet()
        {
        }
    }
}
