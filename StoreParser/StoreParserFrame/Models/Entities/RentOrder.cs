namespace StoreParser.Models.Entities
{
    public class RentOrder
    {
        public RentOrder()
        {
            Location = string.Empty;
            RoomCount = 0;
            Price = 0;
            Floor = 0;
            Space = double.NaN;
        }

        public string  Location { get; set; }
        public int? RoomCount { get; set; }
        public int? Price { get; set; }
        public int? Floor { get; set; }
        public double? Space { get; set; }
    }
}
