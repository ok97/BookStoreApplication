using BookStoreApplication.Contracts;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class WishListController : ControllerBase
    {
        //Declare private object for logger object
        private readonly ILoggerService _logger;
        private IWishListBL wishListBL;
        public WishListController(IWishListBL wishListBL, ILoggerService logger)
        {
            this.wishListBL = wishListBL;
            this._logger = logger;
        }

        [HttpPost]
        public IActionResult AddBookToWishList(int BookId)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = this.wishListBL.AddBookToWishList(UserId, BookId);
                if (data != null)
                {
                    _logger.LogInfo($"Book Added To WishList Successfully {UserId}"); // Logger Info
                    return this.Ok(new { status = "True", message = "Book Added To WishList Successfully", data });
                }
                else
                {
                    _logger.LogError($"Failed To Add WishList {UserId}"); // Logger Error 
                    return this.BadRequest(new { status = "False", message = "Failed To Add WishList" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }


        [HttpGet]
        public IActionResult GetListOfBooksInWishlist()
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = wishListBL.GetListOfBooksInWishlist(UserId);
                if (idClaim != null)
                {
                    _logger.LogInfo($"List of Wishlist Fetched Successfully {UserId}"); // Logger Info              
                    return Ok(new { success = true, message = "List of Wishlist Fetched Successfully", data });
                }
                else
                {
                    _logger.LogError($"Failed To Fetch WishList {UserId}"); // Logger Error 
                    return NotFound(new { success = true, message = "Failed To Fetch WishList" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete("wishlistid")]
        public IActionResult DeleteWishListById(int wishlistid)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                bool data = wishListBL.DeleteWishListById(UserId, wishlistid);
                if (!data.Equals(false))
                {
                    _logger.LogInfo($"WishList Delete Successfully {UserId}"); // Logger Info
                    return this.Ok(new { success = true, message = " WishList Delete Successfully" });
                }
                else
                {
                    _logger.LogError($"Failed To WishList Delete {UserId}"); // Logger Error 
                    return this.NotFound(new { success = false, message = "Failed To WishList Delete" });
                }
            }
            catch (Exception ex)
            {           
                return BadRequest(new { ex.Message });
            }
        }
    }
}
