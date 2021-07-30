using BookStoreApplication.Contracts;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
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


        [HttpPost("Add")]
        public IActionResult AddBookToWishList(int BookId)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = this.wishListBL.AddBookToWishList(UserId, BookId);
                if (data != null)
                {                  
                    return this.Ok(new { status = "True", message = "Book Added To WishList Successfully", data });
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
    }
}
