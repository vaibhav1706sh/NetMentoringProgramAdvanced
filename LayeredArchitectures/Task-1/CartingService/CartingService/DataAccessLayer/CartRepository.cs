using CartingService.Entity;
using LiteDB;

namespace CartingService.DataAccessLayer
{
    public class CartRepository : ICartRepository
    {
        private readonly ILiteCollection<Cart> CartCollection;
        public CartRepository()
        {
            var db = new LiteDatabase(@"C:\Temp\MyData.db");
            {
                // Get a collection (or create, if doesn't exist)
                CartCollection = db.GetCollection<Cart>("carts");
            }
        }

        public void Upsert(Cart cart)
        {
            CartCollection.Upsert(cart);
        }

        public void Insert(Cart cart)
        {
            CartCollection.Insert(cart);
        }

        public void Update(Cart cart)
        {
            CartCollection.Update(cart);
        }

        public Cart GetCart(string cartId)
        {
            return CartCollection.Find(x => x.CartId == cartId)?.FirstOrDefault();
        }

        public List<Item> GetItems(string cartId)
        {
            return CartCollection.Find(x => x.CartId == cartId)?.FirstOrDefault()?.Items;
        }
    }
}
