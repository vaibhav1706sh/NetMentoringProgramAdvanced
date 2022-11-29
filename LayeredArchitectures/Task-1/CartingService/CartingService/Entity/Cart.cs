namespace CartingService.Entity
{
    public class Cart
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public List<Item> Items { get; set; }
    }
}
