using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class ViewRentModel : PageModel
    {
        private readonly RentInfoService rentInfoService;
        public List<RentInfo> rentInfos { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "RentID";
        public ViewRentModel(RentInfoService rentserv)
        {
            rentInfoService = rentserv;
        }
        public void OnGet()
        {
            var rentinfo = rentInfoService.LoadRentInfo();
            if (!string.IsNullOrEmpty(SearchString))
            {
                rentinfo = rentinfo.Where(c => c.ClientID.Contains(SearchString) ||
                c.CarID.Contains(SearchString) ||
                c.StartDate.Contains(SearchString) ||
                c.Period.Contains(SearchString) ||
                c.EndDate.Contains(SearchString) ||
                c.RentID.ToString().Contains(SearchString)).ToList();    
            }
            rentinfo = SortOrder switch
            {
                "RentID_desc" => rentinfo.OrderByDescending(c => c.RentID).ToList(),
                "ClientID" => rentinfo.OrderBy(c => c.ClientID).ToList(),
                "ClientID_desc" => rentinfo.OrderByDescending(c => c.ClientID).ToList(),
                "CarID" => rentinfo.OrderBy(c => c.CarID).ToList(),
                "CarID_desc" => rentinfo.OrderByDescending(c => c.CarID).ToList(),
                "Period" => rentinfo.OrderBy(c => c.Period).ToList(),
                "Period_desc" => rentinfo.OrderByDescending(c => c.Period).ToList(),
                "EndDate" => rentinfo.OrderBy(c => c.EndDate).ToList(),
                "EndDate_desc" => rentinfo.OrderByDescending(c => c.EndDate).ToList(),
                _ => rentinfo.OrderBy(c => c.RentID).ToList(),
            };
            rentInfos = rentinfo;
        }
        public IActionResult OnPostDelete(int id)
        {
            rentInfoService.DeleteRentInfo(id);
            return RedirectToPage();
        }
    }
}
