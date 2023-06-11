using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    orderDetails = context.OrderDetails.ToList();
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public static List<OrderDetail> FindOrderDetailByOrderId(int orderId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    orderDetails = context.OrderDetails.Where(orderDetail => orderDetail.OrderId == orderId).ToList();
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetails;
        }

        public static List<OrderDetail> FindOrderDetailByFlowerBouquetId(int flowerBouquetId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    orderDetails = context.OrderDetails.Where(orderDetail => orderDetail.FlowerBouquetId == flowerBouquetId).ToList();
                }
            } catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetails;
        }
        
        public static OrderDetail FindOrderDetailByOrderIdAndFlowerBouquetId(int orderId, int flowerBouquetId)
        {
            OrderDetail orderDetail = new OrderDetail();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    orderDetail = context.OrderDetails
                        .SingleOrDefault(orderDetail1 => orderDetail1.FlowerBouquetId == flowerBouquetId && orderDetail1.OrderId == orderId);
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetail;
        }

        public static void SaveOrderDetail(OrderDetail orderDetail)
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

        public static void UpdateOrderDetail(OrderDetail orderDetail)
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

        public static void DeleteOrderDetail(OrderDetail orderDetail)
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
