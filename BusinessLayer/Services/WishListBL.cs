using BusinessLayer.Interfaces;
using CommonLayer.RequestModel;
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
    }
}
