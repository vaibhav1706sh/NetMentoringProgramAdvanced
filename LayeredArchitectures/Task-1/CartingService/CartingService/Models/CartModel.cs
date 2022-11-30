using System.ComponentModel.DataAnnotations;

namespace CartingService.Models
{
    public class CartModel
    {
        [Required]
        public string Id { get; set; }
        public List<ItemModel> Items { get; set; }
    }
}
