using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        public bool AddOrder(int UserId, int CartId,int AddressId);
        public List<OrderResponse> GetListOfOrders(int UserId);
    }
}
