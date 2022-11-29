using CartingService.Models;

namespace CartingService.BusinessLogicLayer
{
    public interface ICartService
    {
        public void AddCart(CartModel cart);
        public void AddItemToCart(ItemModel item);
        public List<ItemModel> GetItems(string cartId);
        public void RemoveItem(string cartId, string itemId);
    }
}
