using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class WishListRL : IWishListRL
    {
        // Add connection code
        private readonly IConfiguration _configuration;
        private SqlConnection connection;
        public WishListRL(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public void SQLConnection()
        {
            string sqlConnectionString = _configuration.GetConnectionString("BookStoreDB");
            connection = new SqlConnection(sqlConnectionString);
        }
        public WishListRequest AddBookToWishList(int UserId, int BookId)
        {
            try
            {
                WishListRequest wishListRequest = new WishListRequest();
                SQLConnection();
                using (SqlCommand cmd = new SqlCommand("sp_AddBookToWishList", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@BookId", BookId);                  
                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                };
                return wishListRequest;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<WishListBookResponse> GetListOfBooksInWishlist(int UserId)
        {
            try
            {
                List<WishListBookResponse> bookList = null;
                SQLConnection();
                bookList = new List<WishListBookResponse>();
                using (SqlCommand cmd = new SqlCommand("sp_GetListOfWishList", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    bookList = ListBookResponseModel(dataReader);
                };
                return bookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<WishListBookResponse> ListBookResponseModel(SqlDataReader dataReader)
        {
            try
            {
                List<WishListBookResponse> bookList = new List<WishListBookResponse>();
                WishListBookResponse responseData = null;
                while (dataReader.Read())
                {
                    responseData = new WishListBookResponse
                    {
                        BookId = Convert.ToInt32(dataReader["BookId"]),
                        UserId = Convert.ToInt32(dataReader["UserId"]),
                        WishListId = Convert.ToInt32(dataReader["WishListId"]),
                        Name = dataReader["Name"].ToString(),
                        Author = dataReader["Author"].ToString(),
                        Language = dataReader["Language"].ToString(),
                        Category = dataReader["Category"].ToString(),
                        Pages = dataReader["Pages"].ToString(),
                        Price = dataReader["Price"].ToString()
                        //Quantity = Convert.ToInt32(dataReader["Quantity"])
                    };
                    bookList.Add(responseData);
                }
                return bookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteWishListById(int UserId,int wishlistid)
        {
            try
            {
                SQLConnection();
                using (SqlCommand cmd = new SqlCommand("sp_DeletewishlistidById", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@WishlistId", wishlistid);
                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    //int CardExist = (int)cmd.ExecuteScalar();
                    //if (CardExist > 0)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
