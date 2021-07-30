using BookStoreApplication.Contracts;
using BusinessLayer.Interfaces;
using CommonLayer.RequestModel;
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
    public class AddressController : ControllerBase
    {
        //Declare private object for logger object
        private readonly ILoggerService _logger;
        IAddressBL addressBL;
        public AddressController(ILoggerService logger, IAddressBL addressBL)
        {
            this._logger = logger;
            this.addressBL = addressBL;
        }

        [HttpPost]
        public IActionResult AddAddress(AddressRequest address)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = this.addressBL.AddAddress(UserId, address);
                if (data != null)
                {                   
                    _logger.LogInfo($"Address Added Successfully {UserId}"); // Logger Info
                    return this.Ok(new { status = "True", message = "Address Added Successfully", data });
                }
                else
                {
                    _logger.LogError("Failed To Add Address"); // Logger Error
                    return this.BadRequest(new { status = "False", message = "Failed To Add Address", message1 = "Please Login User " });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetListOfAddress()
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = this.addressBL.GetListOfAddress(UserId);
                if (data != null)
                {
                    _logger.LogInfo($"list Of Address Display Successfully {UserId}"); // Logger Info               
                    return this.Ok(new { status = "True", message = "list Of Address Display Successfully", data });
                }
                else
                {
                    _logger.LogError("No Address Found"); // Logger Error
                    return NotFound(new { success = true, message = "No Address Found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpGet("{addressId}")]
        public IActionResult GetListOfAddressid(int addressId)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = this.addressBL.GetListOfAddressid(UserId, addressId);
                if (data != null)
                {
                    _logger.LogInfo($" Address Display Successfully {UserId}"); // Logger Info
                    return this.Ok(new { status = "True", message = "Address Display Successfully", data });
                }
                else
                {
                    _logger.LogError($"No Address Found {UserId}"); // Logger Error
                    return NotFound(new { success = false, message = "No Address Found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }


        [HttpPut("{AddressId}")]
        public IActionResult UpdateAddress(int AddressId, AddressRequest address)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                var data = this.addressBL.UpdateAddress(UserId, AddressId, address);
                if (idClaim != null)
                {
                    _logger.LogInfo($"Address update Successfully {UserId}"); // Logger Info              
                    return this.Ok(new { status = "True", message = "Address update Successfully", data });
                }
                else
                {
                    _logger.LogError($"Failed Address update {UserId}"); // Logger Error
                    return this.BadRequest(new { status = "False", message = "Failed Address update", message1 = "Please login user" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
        [HttpDelete("{addressid}")]
        public IActionResult DeleteAddressById(int addressid)
        {
            try
            {
                var idClaim = HttpContext.User.Claims.FirstOrDefault(UserId => UserId.Type.Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Convert.ToInt32(idClaim.Value);
                bool result = addressBL.DeleteAddressById(UserId, addressid);
                if (idClaim != null)
                {
                    _logger.LogInfo($"Address Delete Successfully {UserId}"); // Logger Info 
                    return this.Ok(new { success = true, message = " Address Delete Successfully" });
                }
                else
                {
                    _logger.LogError($"No such Address Exist {UserId}"); // Logger Error
                    return this.NotFound(new { success = false, message = "Address Delete Failed", message1 = "Please login User" });
                }
            }
            catch (Exception ex)
            {                
                return BadRequest(new { ex.Message });
            }
        }

    }
}
