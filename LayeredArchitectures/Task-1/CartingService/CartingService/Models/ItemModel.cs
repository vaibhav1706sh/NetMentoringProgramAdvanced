using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CartingService.Models
{
    public class ItemModel
    {
        public string CartId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public ImageModel? Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class ImageModel
    {
        public string Url { get; set; }
        public string AltText { get; set; }
    }
}
