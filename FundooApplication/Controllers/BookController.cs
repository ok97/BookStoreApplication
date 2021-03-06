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
        [HttpPost]
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
                    _logger.LogInfo($"Book Details Added Successfully {adminId}"); // Logger Info
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
                    _logger.LogInfo("Book Fetched Successfully ");
                    return Ok(new { success=true, message = "List of Books Fetched Successfully", data });
                }
                else
                {
                    _logger.LogError("Book Added Failed"); // Logger Error
                    return NotFound(new { success = true, message = "No Books Found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [AllowAnonymous]
        [HttpGet("{bookId}")]
        public IActionResult GetListOfBooksid(int bookId)
        {
            try
            {
                var data = bookBL.GetListOfBooksid(bookId);
                if (data != null)
                {
                    _logger.LogInfo($"Book Fetched Successfully{bookId} ");
                    return Ok(new { success = true, message = "List of Books Fetched Successfully", data });
                }
                else
                {
                    _logger.LogError($"No Books Found{bookId}"); // Logger Error
                    return NotFound(new { success = true, message = "No Books Found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut("{bookId}")]
        public IActionResult UpdateBook(int bookId, AddBooks adminbookData)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(AdminId => AdminId.Type.Equals("AdminId", StringComparison.InvariantCultureIgnoreCase));
                int adminId = Convert.ToInt32(idClaim.Value);
                AdminBookResponseData data = bookBL.UpdateBook(bookId, adminId, adminbookData);
                bool success = false;
                string message;
                if (adminbookData == null)
                {
                    _logger.LogError("Book Update Failed"); // Logger Error
                    message = $"Book Update Failed";
                    return Ok(new { success, message });

                }
                else
                {
                    _logger.LogInfo($"Book Update Successfully {bookId}"); // Logger Info
                    success = true;
                    message = $"Book Update Successfully {bookId}";
                    return Ok(new { success, message, data });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete("{bookId}")]
        public IActionResult DeleteBookById(int bookId)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(AdminId => AdminId.Type.Equals("AdminId", StringComparison.InvariantCultureIgnoreCase));
                int adminId = Convert.ToInt32(idClaim.Value);
                bool result = bookBL.DeleteBookById(adminId, bookId);
                if (!result.Equals(false))
                {
                    _logger.LogInfo($"Book Delete Successfully {bookId}"); // Logger Info
                    return this.Ok(new { success = true, message = " Books Delete Successfully" });
                }
                else
                {
                    _logger.LogError("Book Delete Failed"); // Logger Error
                    return this.NotFound(new { success = false, message = "No such Books Id Exist" });
                }
            }
            catch (Exception ex)
            {                
                return BadRequest(new { ex.Message });
            }
        }

    }
}
