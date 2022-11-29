using static System.Net.Mime.MediaTypeNames;

namespace CartingService.Entity
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Image? Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
        public string AltText { get; set; }
    }
}
