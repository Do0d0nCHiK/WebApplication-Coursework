using System.Security.Cryptography.X509Certificates;

namespace WebApplication2
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FatherName {  get; set; }
        public string Passport { get; set; }
        public Contact(int _id, string _firstname, string _lastname, string _phonenumber, string fatherName, string passport) : base()
        {
            Id = _id;
            FirstName = _firstname;
            LastName = _lastname;
            PhoneNumber = _phonenumber;
            FatherName = fatherName;
            Passport = passport;
        }
        public Contact()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            FatherName = "";
            Passport = "";
        }
    }
}
