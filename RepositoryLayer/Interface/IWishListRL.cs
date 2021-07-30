using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IWishListRL
    {
        public WishListRequest AddBookToWishList(int UserId, int BookId);
        public List<WishListBookResponse> GetListOfBooksInWishlist(int UserId);
        public bool DeleteWishListById(int UserId,int wishlistid);
    }
}
