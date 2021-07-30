using BusinessLayer.Interfaces;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
   public class ReviewBL: IReviewBL
    {
        IReviewRL reviewRL;
        public ReviewBL(IReviewRL reviewRL)
        {
            this.reviewRL = reviewRL;
        }

        public ReviewRequest AddReview(int bookId, int UserId, ReviewRequest review)
        {
            return this.reviewRL.AddReview(bookId, UserId, review);
        }

        public List<ReviewListBookResponse> GetListOfReview(int UserId)
        {
            try
            {
                return this.reviewRL.GetListOfReview(UserId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
