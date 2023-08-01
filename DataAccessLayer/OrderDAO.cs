using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class OrderDAO
    {
        private static OrderDAO instance;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public static List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    orders = context.Orders
                        .Include(x => x.Customer)
                        .ToList();
                }
            } catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        public static Order Get(int orderId) 
        {
            Order order = new Order();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    order = context.Orders
                        .Include (x => x.Customer)
                        .Include(x => x.OrderDetails)
                        .SingleOrDefault(o => o.OrderId == orderId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }
        public static void Save(Order order) {
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
        public static void Update(Order order) {
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
        public static void Delete(Order order) {
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
    }
}
