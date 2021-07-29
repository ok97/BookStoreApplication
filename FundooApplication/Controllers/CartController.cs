using BookStoreApplication.Contracts;
using BusinessLayer.Interfaces;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{

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
        [HttpPost("Add")]
        public IActionResult AddBookToCart(CartRequest cart)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                      


                if (idClaim != null)
                {
                    int UserId = Convert.ToInt32(idClaim.Value);
                    var data = this.cartBL.AddBookToCart(UserId, cart.BookId);
                    return this.Ok(new { status = "True", message = "Book Added To Cart Successfully", data });
                }
                else
                {

                    return this.BadRequest(new { status = "False", message = "Failed To Add Cart", message1 = "Please Login User " });
                }

            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet("GetCard")]
        public IActionResult GetListOfBooksInCart()
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));

                if (idClaim != null)
                {
                    int UserId = Convert.ToInt32(idClaim.Value);
                    var data = cartBL.GetListOfBooksInCart(UserId);
                    return Ok(new { success = true, message = "List of Carts Fetched Successfully", data });
                }
                else
                {

                    return NotFound(new { success = true, message = "Please Login User And Then Access" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }


        [HttpPut("Update")]
        public IActionResult AddBookQuantityintoCart(int BookId, int quantity)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
               
                if (idClaim != null)
                {
                    int UserId = Convert.ToInt32(idClaim.Value);
                    var data = this.cartBL.AddBookQuantityintoCart(UserId, BookId, quantity);
                    return this.Ok(new { status = "True", message = "Quantity Add Cart Successfully", data });
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Failed To Quantity Add Cart", message1 = "Please login user" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCartById(string id)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
               
                if (idClaim != null)
                {
                    int UserId = Convert.ToInt32(idClaim.Value);
                    bool result = cartBL.DeleteCartById(UserId, id);
                    return this.Ok(new { success = true, message = " Card Delete Successfully" });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "No such CartId Exist", message1 = "Please login User" });
                }
            }
            catch (Exception ex)
            {
                bool success = false;
                return BadRequest(new { ex.Message });
            }
        }

    }
}
