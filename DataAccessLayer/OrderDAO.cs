using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    orders = context.Orders.ToList();
                }
            } catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        public static Order FindOrderById(int orderId) 
        {
            Order order = new Order();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    order = context.Orders.SingleOrDefault(o => o.OrderId == orderId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }
        public static Order FindOrderByIdIncludeCustomer(int orderId)
        {
            Order order = new Order();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    order = context.Orders
                        .Include(o => o.Customer)
                        .SingleOrDefault(o => o.OrderId == orderId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }
        public static List<Order> FindOrderByCustomerId(int customerId)
        {
            List <Order> orders = new List<Order>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    orders = context.Orders.Where(order => order.CustomerId == customerId).ToList();
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }
        public static void SaveOrder(Order order) {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateOrder(Order order) {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Orders.Update(order);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteOrder(Order order) {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static Order GetOrderWithTheLargestOrderId()
        {
            Order order = new Order();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    order = context.Orders.OrderByDescending(o => o.OrderId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }
    }
}
