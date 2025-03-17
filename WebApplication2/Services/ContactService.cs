using System.Text.Json;
namespace WebApplication2
{
    public class ContactService
    {
        private const string FilePath = "Data\\ClientData.json";
        private readonly object _lock = new();

        public List<Contact> LoadContacts()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Contact>();
            }

            string json = File.ReadAllText(FilePath);
            if (json != null && json != "")
                return JsonSerializer.Deserialize<List<Contact>>(json);
            else return new List<Contact>();
        }

        public void SaveContacts(List<Contact> contacts)
        {
            string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            lock(_lock)
            {
                File.WriteAllText(FilePath, json);
            }
        }
        public void AddContact(Contact contact)
        {
            var contacts = LoadContacts();
            contact.Id = contacts.Count > 0 ? contacts.Max(c => c.Id) + 1 : 1;
            contacts.Add(contact);
            SaveContacts(contacts);
        }

        public void DeleteContact(int id)
        {
            var contacts = LoadContacts();
            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact != null)
            {
                contacts.Remove(contact);
                SaveContacts(contacts);
            }
        }

    }
}
