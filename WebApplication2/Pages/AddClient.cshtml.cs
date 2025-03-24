using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebApplication2.Pages
{
    public class AddClientModel : PageModel
    {
        private readonly ContactService _contactService;
        public AddClientModel(ContactService contactService)
        {
            _contactService = contactService;
        }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string FatherName { get; set; }
        [BindProperty]
        public string Passport { get; set; }
        public IActionResult OnPost()
        {
            ModelState["FatherName"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Phone = "+7" + Phone;
            if (FatherName == null || FatherName == "")
            {
                FatherName = "нет";
            }
            Contact cnt = new Contact
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                FatherName = this.FatherName,
                Passport = this.Passport,
                PhoneNumber = Phone,
            };
            _contactService.AddContact(cnt);
            return RedirectToPage("./AddClient");
        }
        public void OnGet()
        {
        }
    }
}
