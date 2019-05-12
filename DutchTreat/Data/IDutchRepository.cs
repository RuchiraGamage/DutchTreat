using System.Collections.Generic;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string catagory);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(string name,int id);
        void AddOrder(Order newOrder);

        bool SaveAll();
        void AddEntity(object model);
        IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems);
    }
}