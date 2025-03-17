using System.Text.Json;

namespace WebApplication2
{
    public class RentInfoService
    {
        private const string Path = "Data\\RentInfoData.json";
        private readonly object _lock = new();
        public List<RentInfo> LoadRentInfo()
        {
            if (!File.Exists(Path))
            {
                return new List<RentInfo>();
            }
            string json = File.ReadAllText(Path);
            if (json != null && json != "")
                return JsonSerializer.Deserialize<List<RentInfo>>(json);
            else return new List<RentInfo>();
        }
        public void SaveRentInfo(List<RentInfo> rentinfo)
        {
            string json = JsonSerializer.Serialize(rentinfo, new JsonSerializerOptions { WriteIndented = true });
            lock (_lock)
            {
                File.WriteAllText(Path, json);
            }
        }
        public void AddNewRentInfo(RentInfo rentinfo)
        {
            var _rentinfo = LoadRentInfo();
            rentinfo.RentID = _rentinfo.Count > 0 ? _rentinfo.Max(c => c.RentID) + 1 : 1;
            _rentinfo.Add(rentinfo);
            SaveRentInfo(_rentinfo);
        }
        public void DeleteRentInfo(int id)
        {
            var _rentsinfo = LoadRentInfo();
            var carinfo = _rentsinfo.FirstOrDefault(c => c.RentID == id);
            if (carinfo != null)
            {
                _rentsinfo.Remove(carinfo);
                SaveRentInfo(_rentsinfo);
            }
        }
    }
}
