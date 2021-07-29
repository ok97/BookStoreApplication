using BusinessLayer.Interfaces;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
   public class OrderBL: IOrderBL
    {
        IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;

        }

        public bool AddOrder(int UserId, int CartId,int AddressId)
        {
            return this.orderRL.AddOrder(UserId, CartId, AddressId);
        }

        public List<OrderResponse> GetListOfOrders(int UserId)
        {
            try
            {
                return this.orderRL.GetListOfOrders(UserId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
