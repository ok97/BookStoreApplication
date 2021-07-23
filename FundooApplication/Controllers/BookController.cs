using BookStoreApplication.Contracts;
using BusinessLayer.Interfaces;
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
        public BookController(IBookBL bookBl, ILoggerService logger)
        {
            this.bookBL = bookBl;
            this._logger = logger;

        }
        //[HttpPost("AddBook")]
        //public IActionResult AddBook()
        //{ 



        //}



    } 
}
