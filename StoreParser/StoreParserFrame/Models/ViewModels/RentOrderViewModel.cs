namespace StoreParser.Models.ViewModels
{
    public class RentOrderViewModel
    {
        public RentOrderViewModel(string location, string roomCount, string price, string floor, string space)
        {
            Location = location;
            RoomCount = roomCount;
            Price = price;
            Floor = floor;
            Space = space;
        }

        public string Location { get; set; }
        public string RoomCount { get; set; }
        public string Price { get; set; }
        public string Floor { get; set; }
        public string Space { get; set; }
    }
}
