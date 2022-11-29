using CartingService.DataAccessLayer;
using CartingService.Entity;
using CartingService.Models;

namespace CartingService.BusinessLogicLayer
{
    public class CartService:ICartService
    {
        private readonly ICartRepository cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public void AddCart(CartModel cart)
        {
            var entity = new Cart
            {
                CartId = cart.CartId,
                Id = cart.Id,
                Items = cart?.Items?.Select(x => new Item
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Image = new Image
                    {
                        Url = x.Image?.Url,
                        AltText = x.Image?.AltText
                    }
                }).ToList()
            };

            cartRepository.Insert(entity);
        }

        public void AddItemToCart(ItemModel item)
        {
            var cart = cartRepository.GetCart(item.CartId);
            if (cart == null) throw new Exception("Cart does not exist");
            if(cart.Items==null) cart.Items = new List<Item>();
            cart.Items.Add(new Item
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                Image = new Image
                {
                    Url = item.Image?.Url,
                    AltText = item.Image?.AltText
                }
            });
            cartRepository.Upsert(cart);
        }

        public List<ItemModel> GetItems(string cartId)
        {
            var items = cartRepository.GetItems(cartId);
            return items?.Select(x => new ItemModel
            {
                CartId = cartId,
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                Image = new ImageModel
                {
                    Url = x.Image?.Url,
                    AltText = x.Image?.AltText
                }
            }).ToList();
        }

        public void RemoveItem(string cartId, string itemId)
        {
            var cart = cartRepository.GetCart(cartId);
            if (cart == null) throw new Exception("Cart does not exist");
            if(cart.Items==null) throw new Exception($"Item ({itemId}) does not exist in the cart ({cartId})");
            var item = cart.Items.FirstOrDefault(x => x.Id == itemId);
            if(item==null) throw new Exception($"Item ({itemId}) does not exist in the cart ({cartId})");
            cart.Items.Remove(item);
            cartRepository.Upsert(cart);
        }
    }
}
