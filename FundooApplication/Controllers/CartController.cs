using BookStoreApplication.Contracts;
using BusinessLayer.Interfaces;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        //Declare private object for logger object
        private readonly ILoggerService _logger;
        private ICartBL cartBL;
        public CartController(ILoggerService logger, ICartBL cartBL)
        {
            this.cartBL = cartBL;
            this._logger = logger;
        }

        [HttpPost]
        public IActionResult AddBookToCart(int BookId)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = this.cartBL.AddBookToCart(UserId, BookId);
                if (idClaim != null)
                {
                    _logger.LogInfo($"Cart Added Successfully {UserId}"); // Logger Info              
                    return this.Ok(new { status = "True", message = "Book Added To Cart Successfully", data });
                }
                else
                {
                    _logger.LogError($"Cart Added Failed {UserId}"); // Logger Error
                    return this.BadRequest(new { status = "False", message = "Failed To Add Cart" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        public IActionResult GetListOfBooksInCart()
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = cartBL.GetListOfBooksInCart(UserId);
                if (data != null)
                {
                    _logger.LogInfo($"Carts Fetched Successfully {UserId}"); // Logger Info                  
                    return Ok(new { success = true, message = "List of Carts Fetched Successfully", data });
                }
                else
                {
                    _logger.LogError($"Cart Fetched Failed {UserId}"); // Logger Error
                    return NotFound(new { success = true, message = "Cart Fetched Failed" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut]
        public IActionResult AddBookQuantityintoCart(int BookId, int quantity)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = this.cartBL.AddBookQuantityintoCart(UserId, BookId, quantity);
                if (idClaim != null)
                {
                    _logger.LogInfo($"Quantity Add Cart Successfully"); // Logger Info          
                    return this.Ok(new { status = "True", message = "Quantity Add Cart Successfully", data });
                }
                else
                {
                    _logger.LogError($"Failed To Quantity Add Cart"); // Logger Error
                    return this.BadRequest(new { status = "False", message = "Failed To Quantity Add To Cart", message1 = "Please login user" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCartById(int id)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                bool result = cartBL.DeleteCartById(UserId, id);
                if (idClaim != null)
                {
                    _logger.LogInfo($"Card Delete Successfully"); // Logger Info                     
                    return this.Ok(new { success = true, message = " Card Delete Successfully" });
                }
                else
                {
                    _logger.LogError($"Failed Card Delete"); // Logger Error
                    return this.NotFound(new { success = false, message = "No such CartId Exist" });
                }
            }
            catch (Exception ex)
            {               
                return BadRequest(new { ex.Message });
            }
        }
    }
}
