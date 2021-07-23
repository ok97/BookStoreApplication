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
    public class BookController : ControllerBase
    {
        //Declare private object for logger object
        private readonly ILoggerService _logger;

        IBookBL bookBL;
        public BookController(IBookBL bookBL, ILoggerService logger)
        {
            this.bookBL = bookBL;
            this._logger = logger;

        }
        [HttpPost("AddBook")]
        //[Route("")]
        public IActionResult AddBook(AddBooks adminbookData)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(AdminId => AdminId.Type.Equals("AdminId", StringComparison.InvariantCultureIgnoreCase));
                int adminId = Convert.ToInt32(idClaim.Value);
                AdminBookResponseData data = bookBL.AddBook(adminId, adminbookData);
                bool success = false;
                string message;
                if (adminbookData == null)
                {
                    _logger.LogError("Book Added Failed"); // Logger Error
                    message = $"Book Added Failed";
                    return Ok(new { success, message });

                }
                else
                {
                    _logger.LogInfo($"Book Added Successfully {adminId}"); // Logger Info
                    success = true;
                    message = $"Book Added Successfully {adminId}";
                    return Ok(new { success, message, data });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetListOfBooks()
        {
            try
            {
                var data =  bookBL.GetListOfBooks();
                if (data != null)
                {                  
                    
                    return Ok(new { success=true, message = "List of Books Fetched Successfully", data });
                }
                else
                {
                   
                    return NotFound(new { success = true, message = "No Books Found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult DeleteBookById(string id)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(AdminId => AdminId.Type.Equals("AdminId", StringComparison.InvariantCultureIgnoreCase));
                int adminId = Convert.ToInt32(idClaim.Value);
                bool result = bookBL.DeleteBookById(adminId,id);
                if (!result.Equals(false))
                {
                    return this.Ok(new { success = true, message = " Books Delete Successfully" });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "No such BooksId Exist" });
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
