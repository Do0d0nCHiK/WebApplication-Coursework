using System.Text.Json;

namespace WebApplication2
{
    public class CarInfoService
    {
        private const string Path = "Data\\CarInfoData.json";
        private readonly object _lock = new();

        public List<CarInfo> LoadCarInfo()
        {
            if (!File.Exists(Path))
            {
                return new List<CarInfo>();
            }
            string json = File.ReadAllText(Path);
            if (json != null && json!="")
                return JsonSerializer.Deserialize<List<CarInfo>>(json);
            else return new List<CarInfo>();
        }
        public void SaveCarInfo(List<CarInfo> carinfo)
        {
            string json = JsonSerializer.Serialize(carinfo, new JsonSerializerOptions { WriteIndented = true });
            lock (_lock)
            {
                File.WriteAllText(Path, json);
            }
        }
        public void AddNewCarInfo(CarInfo carinfo)
        {
            var _carsinfo = LoadCarInfo();
            carinfo.Id = _carsinfo.Count > 0 ? _carsinfo.Max(c => c.Id) + 1 : 1;
            _carsinfo.Add(carinfo);
            SaveCarInfo(_carsinfo);
        }
        public void DeleteCarInfo(int id)
        {
            var _carsinfo = LoadCarInfo();
            var carinfo = _carsinfo.FirstOrDefault(c => c.Id == id);
            if (carinfo != null)
            {
                _carsinfo.Remove(carinfo);
                SaveCarInfo(_carsinfo);
            }
        }
    }
}
