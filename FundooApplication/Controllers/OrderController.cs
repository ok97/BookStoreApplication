﻿using BookStoreApplication.Contracts;
using BusinessLayer.Interfaces;
using CommonLayer.RequestModel;
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
    public class OrderController : ControllerBase
    {
        //Declare private object for logger object
        private readonly ILoggerService _logger;
        private IOrderBL orderBL;
        public OrderController(ILoggerService logger, IOrderBL orderBL)
        {
            this.orderBL = orderBL;
            this._logger = logger;
        }

        [HttpPost("Add")]
        public IActionResult AddOrder(OrderRequest order)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                if (idClaim != null)
                {
                    int UserId = Convert.ToInt32(idClaim.Value);
                    var data = this.orderBL.AddOrder(UserId, order.CartId,order.AddressId);
                    return this.Ok(new { status = "True", message = "Order Successfull", data });
                }
                else
                {

                    return this.BadRequest(new { status = "False", message = "Failed To Order", message1 = "Please Login User " });
                }

            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        public IActionResult GetListOfOrders()
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));

                if (idClaim != null)
                {
                    int UserId = Convert.ToInt32(idClaim.Value);
                    var data = orderBL.GetListOfOrders(UserId);
                    return Ok(new { success = true, message = "List of Orders Fetched Successfully", data });
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


    }
}
