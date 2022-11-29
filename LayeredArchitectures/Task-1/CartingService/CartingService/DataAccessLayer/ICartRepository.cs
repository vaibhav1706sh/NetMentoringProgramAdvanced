using CartingService.Entity;

namespace CartingService.DataAccessLayer
{
    public interface ICartRepository
    {
        public void Upsert(Cart cart);
        public Cart GetCart(string cartId);
        public List<Item> GetItems(string cartId);
        public void Update(Cart cart);
        public void Insert(Cart cart);
    }
}
