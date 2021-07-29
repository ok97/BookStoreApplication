﻿using BusinessLayer.Interfaces;
using CommonLayer.ResponseModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
   public class OrderBL: IOrderBL
    {
        IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;

        }

        public bool AddOrder(int UserId, int CartId,int AddressId)
        {
            return this.orderRL.AddOrder(UserId, CartId, AddressId);
        }

        public List<OrderResponse> GetListOfOrders(int UserId)
        {
            try
            {
                return this.orderRL.GetListOfOrders(UserId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<OrderResponse> GetOrders(int UserId ,int CartId)
        {
            try
            {
                return this.orderRL.GetOrders(UserId, CartId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteOrderById(int UserId, int OrderId)
        {
            return this.orderRL.DeleteOrderById(UserId, OrderId);
        }
    }
}
