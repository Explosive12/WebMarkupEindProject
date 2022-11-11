using System;
using System.Collections.Generic;
using OrderSystemDAL;
using OrderSystemModel;

namespace OrderSystemLogic
{
    public class MenuItemService
    {
        private MenuItemDao menuItemDao = new();

        public List<MenuItem> GetMenuItemsByCategory(int categoryId)
            => menuItemDao.GetMenuItemsByCategory(categoryId);

        public List<MenuItem> GetOrderItemByTableNumber(int tableNumber)
            => menuItemDao.GetOrderItemByTableNumber(tableNumber);
        
    }
}
