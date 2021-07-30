using BusinessLayer.Interfaces;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AddressBL: IAddressBL
    {
        IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
           this.addressRL = addressRL;
        }

        public AddressResponseData AddAddress(int UserId, AddressRequest address)
        {
            try
            {
                AddressResponseData adminbookResponseData = addressRL.AddAddress(UserId, address);
                return adminbookResponseData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        public List<AddressResponseData> GetListOfAddress(int UserId)
        {
            try
            {
                return this.addressRL.GetListOfAddress(UserId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public List<AddressResponseData> GetListOfAddressid(int UserId, int addressId)
        {
            try
            {
                return this.addressRL.GetListOfAddressid(UserId, addressId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }       

        public bool UpdateAddress(int UserId, int AddressId, AddressRequest address)
        {
            try
            {
                return this.addressRL.UpdateAddress(UserId, AddressId, address);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        public bool DeleteAddressById(int UserId, int addressid)
        {
            try
            {
                return this.addressRL.DeleteAddressById(UserId, addressid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }
    }
}
