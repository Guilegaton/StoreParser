namespace StoreParser.Models.ParseModels
{
    public class RentParseOrder
    {
        public RentParseOrder()
        {
            Location = string.Empty;
            Floor = string.Empty;
            Space = string.Empty;
            Price = string.Empty;
            RoomCount = string.Empty;
        }

        public string Location { get; set; }
        public string RoomCount { get; set; }
        public string Price { get; set; }
        public string Floor { get; set; }
        public string Space { get; set; }
    }
}
