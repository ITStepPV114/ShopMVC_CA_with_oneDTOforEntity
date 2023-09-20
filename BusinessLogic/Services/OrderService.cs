using AutoMapper;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace ShopMVC.Services
{
    public class OrdersService : IOrdersService
    {

        private readonly IRepository<Order> _repoOrder;
        private readonly IRepository<Product> _repoProduct;
        private readonly ICartService _cartService;

        public OrdersService(IRepository<Order> repoOrder,
                             IRepository<Product> repoProduct,
                             ICartService cartService)
        {
            _repoOrder = repoOrder;
            _repoProduct = repoProduct;
           _cartService = cartService;
        }
       
        public void Create(string userId, List<int> idList)
        {            
            List<Product> products = idList.Select(id =>_repoProduct.GetByID(id)).ToList();
            Order newOrder = new Order()
            {
                OrderDate = DateTime.Now,
                IdsProduct = JsonSerializer.Serialize(idList),
                TotalPrice = products.Sum(p => p.Price),
                UserId = userId
            };

            _repoOrder.Insert(newOrder);
            _repoOrder.Save();
        }

        public IEnumerable<Order> GetAll(string userId)
        {
            //return _context.Orders.Where(o => o.UserId == userId).ToList();
          //  return _repoOrder.Get(filter:o => o.UserId == userId).ToList();
            return _repoOrder.Get(filter:o => o.UserId == userId, includeProperties: "Category" ).ToList();
        }

        //public Order GetById(int id, string userId)
        //{
            
        //}
    }
}
