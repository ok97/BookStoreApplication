using CommonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IWishListRL
    {
        public WishListRequest AddBookToWishList(int UserId, int BookId);
    }
}
