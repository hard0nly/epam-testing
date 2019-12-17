namespace TestAutomation.Models
{
    public class BookingInfo
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

        public BookingInfo(string name, string phone, string city, string dateFrom, string dateTo)
        {
            Name = name;
            Phone = phone;
            City = city;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}
