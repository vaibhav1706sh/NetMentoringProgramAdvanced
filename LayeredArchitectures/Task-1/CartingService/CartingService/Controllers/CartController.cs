using CartingService.BusinessLogicLayer;
using CartingService.Entity;
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
        [Route("items/{cartId}")]
        public IActionResult Get(string cartId)
        {
            if (string.IsNullOrEmpty(cartId)) return BadRequest("cartId cannot be null or empty");
            return Ok(_cartService.GetItems(cartId));
        }

        [HttpPost]
        [Route("{cartId}/item/add")]
        public IActionResult AddItem(string cartId, ItemModel model)
        {
            if (string.IsNullOrEmpty(cartId)) return BadRequest("cartId cannot be null or empty");
            _cartService.AddItemToCart(model, cartId);
            return Ok();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCart(CartModel model)
        {
            if (string.IsNullOrEmpty(model.Id)) return BadRequest("cartId cannot be null or empty");
            if(_cartService.CartExists(model.Id)) return BadRequest($"cart already exists with cartId:{model.Id}");
            _cartService.AddCart(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{cartId}/item/{itemId}")]
        public IActionResult RemoveItem(string cartId, string itemId)
        {
            if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(itemId)) return BadRequest("cartId and/or itemId cannot be null or empty");
            _cartService.RemoveItem(cartId, itemId);
            return Ok();
        }
    }
}
