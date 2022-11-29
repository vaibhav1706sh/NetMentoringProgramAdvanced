namespace CartingService.Models
{
    public class CartModel
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public List<ItemModel> Items { get; set; }
    }
}
