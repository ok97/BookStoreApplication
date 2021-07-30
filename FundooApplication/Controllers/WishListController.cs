﻿using BookStoreApplication.Contracts;
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
                    return this.Ok(new { status = "True", message = "Book Added To WishList Successfully", data });
                }
                else
                {

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

                if (idClaim != null)
                {
                    int UserId = Convert.ToInt32(idClaim.Value);
                    var data = wishListBL.GetListOfBooksInWishlist(UserId);
                    return Ok(new { success = true, message = "List of Wishlist Fetched Successfully", data });
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

        [HttpDelete]
        public IActionResult DeleteWishListById(int wishlistid)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                bool data = wishListBL.DeleteWishListById(UserId, wishlistid);
                if (!data.Equals(false))
                {                    
                    return this.Ok(new { success = true, message = " WishList Delete Successfully" });
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
