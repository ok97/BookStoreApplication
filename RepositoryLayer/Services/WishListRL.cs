using CommonLayer.RequestModel;
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
    }
}
