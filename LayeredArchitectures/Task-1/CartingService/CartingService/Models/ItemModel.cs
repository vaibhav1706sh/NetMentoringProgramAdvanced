using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CartingService.Models
{
    public class ItemModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ImageModel? Image { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class ImageModel
    {
        public string Url { get; set; }
        public string AltText { get; set; }
    }
}
