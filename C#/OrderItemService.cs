using System.Collections.Generic;
using OrderSystemDAL;
using OrderSystemModel;

namespace OrderSystemLogic
{
    public class OrderItemService
    {
        private OrderItemDao orderItemDao;

        public OrderItemService()
        {
            this.orderItemDao = new OrderItemDao();
        }

          // Add order Item to list
           public List<OrderItem> AddOrderItems(Order order)
           {
               foreach (OrderItem orderItem in order.OrderItems)
               {
                   orderItem.OrderNumber = order.OrderNumber;
                   orderItemDao.AddOrderItem(orderItem);
               }
             return order.OrderItems;
           }

        // Get a list of orderitems with names of the items
        public List<OrderItem> GetOrderItemsNamesByOrder(Order order)
            => orderItemDao.GetOrderItemById(order);
        
        // Get a list of ordered drinks
        public List<OrderItem> GetOrderdDrinks(Order order)
            => orderItemDao.GetDrinkOrdersItemById(order);
        
        // Get a list of ordered dishes
        public List<OrderItem> GetOrderdDishes(Order order)
            => orderItemDao.GetFoodOrdersItemById(order);
   
        // Change status of ordered item to delivered
        public void ChangeDeliveryStatus(int OrderItemId)
            => orderItemDao.ChangeDeliveryStatus(OrderItemId);
   
        // Get a list of drinks that are ready to deliver
        public List<OrderItem> GetReadyDrinkItems(Order order)
            => orderItemDao.GetReadyDrinkItemsById(order);
        
        // Get a list of  food dishes who ar ready to deliver
        public List<OrderItem> GetReadyFoodItems(Order order)
            => orderItemDao.GetReadyFoodItemsById(order);
        
        // Updates ordered item to Ready to deliver
        public void ReadyToDeliver(int orderItem)
            => orderItemDao.OrderItemReady(orderItem);
        
        // Set orderitem to NOT YET READY to deliver
        public void NotReadyToDeliver(int orderItem)
            => orderItemDao.OrderItemNotReady(orderItem);

        // Updates a whole drink order to ready to deliver
        public void DrinkOrderReadyToDeliver(Order order)
            => orderItemDao.DrinkOrderReady(order);

        // Updates a whole food order to ready to deliver
        public void FoodOrderReadyToDeliver(Order order)
            => orderItemDao.FoodOrderReady(order);

        // Updates orderitem status to delivered
        public void OrderItemDelivered(OrderItem orderItem)
            => orderItemDao.OrderItemDelivered(orderItem);

        // Get a list of orderitems that are delivered
        public List<OrderItem> GetOrderItemsByOrderAndDelivered(Order order)
            => orderItemDao.GetOrderItemsByOrderAndDelivered(order);
    }
}
