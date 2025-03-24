using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class ViewClientsModel : PageModel
    {
        private readonly ContactService _contactService;
        public List<Contact> Contacts { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "ID";
        public ViewClientsModel(ContactService contactService)
        {
            _contactService = contactService;
        }
        public void OnGet()
        {
            var contacts = _contactService.LoadContacts();
            if (!string.IsNullOrEmpty(SearchString))
            {
                contacts = contacts.Where(c => c.FirstName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                c.LastName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                c.PhoneNumber.Contains(SearchString) ||
                c.FatherName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                c.Passport.Contains(SearchString)||
                c.Id.ToString().Contains(SearchString)).ToList();
            }
            contacts = SortOrder switch
            {
                "ID_desc" => contacts.OrderByDescending(c => c.Id).ToList(),
                "FirstName_desc" => contacts.OrderByDescending(c => c.FirstName).ToList(),
                "LastName" => contacts.OrderBy(c => c.LastName).ToList(),
                "LastName_desc" => contacts.OrderByDescending(c => c.LastName).ToList(),
                "FatherName_desc" => contacts.OrderByDescending(c => c.FatherName).ToList(),
                "FatherName" => contacts.OrderBy(c => c.FatherName).ToList(),
                "Phone" => contacts.OrderBy(c => c.PhoneNumber).ToList(),
                "Phone_desc" => contacts.OrderByDescending(c => c.PhoneNumber).ToList(),
                "Passport_desc" => contacts.OrderByDescending(c => c.Passport).ToList(),
                "Passport" => contacts.OrderBy(c => c.Passport).ToList(),
                _ => contacts.OrderBy(c => c.Id).ToList(),
            };
            Contacts = contacts;
        }
        public IActionResult OnPostDelete(int id)
        {
            _contactService.DeleteContact(id);
            return RedirectToPage();
        }
    }
}
