namespace WebApplication2
{
    public class RentInfo
    {
        public int RentID { get; set; }
        public string ClientID { get; set; }
        public string CarID { get; set; }
        public string Period { get; set; }
        public string EndDate { get; set; }
        public string StartDate { get; set; }

        public RentInfo(int _rentid, string _clietnid, string _carid,string _period  ,string _enddate, string _startdate)
        {
            RentID = _rentid;
            ClientID = _clietnid;
            CarID = _carid;
            Period = _period;
            EndDate = _enddate;
            StartDate = _startdate;
        }
        public RentInfo() 
        {
            RentID = 0;
            ClientID = "";
            CarID = "";
            Period = "";
            EndDate = "";
            StartDate = "";
        }
    }
}
