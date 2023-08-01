using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public static List<OrderDetail> GetAll()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    orderDetails = context.OrderDetails
                        .Include(x => x.FlowerBouquet)
                        .ToList();
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }
        
        public static OrderDetail Get(int orderId, int flowerBouquetId)
        {
            OrderDetail orderDetail = new OrderDetail();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    orderDetail = context.OrderDetails
                        .Include(x => x.FlowerBouquet)
                        .SingleOrDefault(orderDetail1 => orderDetail1.FlowerBouquetId == flowerBouquetId && orderDetail1.OrderId == orderId);
                }
            } catch (Exception e)
            {
                throw e;
            }
            return orderDetail;
        }

        public static void Save(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Update(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.OrderDetails.Update(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Delete(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.OrderDetails.Remove(orderDetail);
                    context.SaveChanges();
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
