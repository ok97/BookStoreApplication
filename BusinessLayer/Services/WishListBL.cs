using BusinessLayer.Interfaces;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
   public class WishListBL: IWishListBL
    {
        IWishListRL wishListRL;
        public WishListBL(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }
        public WishListRequest AddBookToWishList(int UserId, int BookId)
        {
            return this.wishListRL.AddBookToWishList(UserId, BookId);
        }

        public List<WishListBookResponse> GetListOfBooksInWishlist(int UserId)
        {
            try
            {
                return this.wishListRL.GetListOfBooksInWishlist(UserId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeleteWishListById(int UserId, int wishlistid)
        {
            return this.wishListRL.DeleteWishListById(UserId,wishlistid);
        }
    }
}
