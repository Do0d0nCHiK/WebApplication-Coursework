namespace WebApplication2
{
    public class CarInfo
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Release { get; set; }
        public string Power { get; set; }
        public string NumberPlate { get; set; }
        public string Cost { get; set; }
        public CarInfo(int _id, string _brand, string _model, string _release, 
                       string _power, string _numberplate, string cost):base()
        {
            Id = _id;
            Brand = _brand;
            Model = _model;
            Release = _release;
            Power = _power;
            NumberPlate = _numberplate;
            Cost = cost;
        }
        public CarInfo()
        {
            Id = Id;
            Brand = "";
            Model = "";
            Release = "";
            Power = "";
            NumberPlate = "";
            Cost = "";
        }
    }
}
