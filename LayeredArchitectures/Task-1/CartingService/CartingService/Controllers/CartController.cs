using CartingService.BusinessLogicLayer;
using CartingService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("{cartId}")]
        public IActionResult Get(string cartId)
        {
            if (string.IsNullOrEmpty(cartId)) return BadRequest("cartId cannot be null or empty");
            return Ok(_cartService.GetItems(cartId));
        }

        [HttpPost]
        [Route("item")]
        public IActionResult AddItem(ItemModel model)
        {
            if (string.IsNullOrEmpty(model.CartId)) return BadRequest("cartId cannot be null or empty");
            _cartService.AddItemToCart(model);
            return Ok();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCart(CartModel model)
        {
            if (string.IsNullOrEmpty(model.CartId)) return BadRequest("cartId cannot be null or empty");
            _cartService.AddCart(model);
            return Ok();
        }

        [HttpDelete]
        [Route("item/{cartId}/{itemId}")]
        public IActionResult RemoveItem(string cartId, string itemId)
        {
            if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(itemId)) return BadRequest("cartId and/or itemId cannot be null or empty");
            _cartService.RemoveItem(cartId, itemId);
            return Ok();
        }
    }
}
