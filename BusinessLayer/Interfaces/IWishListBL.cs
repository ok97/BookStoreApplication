using CommonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IWishListBL
    {
        public WishListRequest AddBookToWishList(int UserId, int BookId);
    }
}
