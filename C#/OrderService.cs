using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystemDAL;
using OrderSystemModel;

namespace OrderSystemLogic
{
    public class OrderService
    {
        private OrderItemDao orderItemDao = new();
        private OrderDao orderDao = new();


        //kan deze weg?
        public Order GetOrderById(int i)
            => orderDao.GetOrderById(i);

        public void AddOrder(Order order)
           => orderDao.AddOrder(order);
        
        
        public void DeleteOrder(Order order)
        {
            orderItemDao.DeleteOrderItemByOrder(order);
            orderDao.DeleteOrder(order);
        }
        
        // UPDATE complete to true
        public void CompleteOrder(int tableNumber)
           => orderDao.CompleteOrder(tableNumber);
        
        public List<Order> GetAllOrdersToday()
           => orderDao.GetAllOrdersToday();
        public List<Order> GetOrdersByTableNumber(int TableNumber)
           => orderDao.GetOrdersByTableNumber(TableNumber);
        public List<Order> GetOrdersToday()
            => orderDao.GetOrdersToday();
        public List<Order> GetOrdersReadyToServe()
            => orderDao.GetOrdersReadyToServe();
        public List<Order> GetNewDrinkOrdersToday()
            => orderDao.GetDrinkOrdersToday();
        public List<Order> GetFoodOrdersToday()
            => orderDao.GetFoodOrdersToday();

        public Order GetTodaysOrderByTable(int tableNumber)
            => orderDao.GetTodaysOrderByTable(tableNumber);

        public List<Order> GetOpenOrderForTable(Order tableNumber)
            => orderDao.GetOpenOrderForTable(tableNumber);
    }
}
