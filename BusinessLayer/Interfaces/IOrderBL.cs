using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IOrderBL
    {
        public bool AddOrder(int UserId, int CartId,int AddressId);
        public List<OrderResponse> GetListOfOrders(int UserId);
    }
}
