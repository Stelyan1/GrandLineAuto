using GrandLineAuto.Data;
using GrandLineAuto.Data.Models.CartEntities;
using GrandLineAuto.Data.Models.OrderEntities;
using GrandLineAuto.Infrastructure.DTO_s.OrderDTO_s;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Repositories.Purchasing.Interfaces;
using GrandLineAuto.Infrastructure.Services.Purchasing.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services.Purchasing
{
    public class OrderService : IOrderService
    {
        private readonly GrandLineAutoDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(GrandLineAutoDbContext dbContext, IOrderRepository orderRepository, ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CheckoutAsync(Guid userId, CheckoutVM model)
        {
            var cartItems = await _cartRepository.All()
                .Where(cr => cr.UserId == userId)
                .Include(cr => cr.Product)
                .ToListAsync();

            if (!cartItems.Any())
            {
                throw new InvalidOperationException("Cart is empty.");
            }

            var order = new Order
            {
                UserId = userId,
                Status = OrderStatus.Pending,
                CreatedOnUtc = DateTime.UtcNow
            };

            foreach(var ci in cartItems)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.Product.Price,
                    ProductName = ci.Product.Name
                });
            }

            order.TotalAmount = order.Items.Sum(i => i.UnitPrice * i.Quantity);

            order.ShippingAddress = new ShippingAddress
            {
                FullName = model.FullName,
                Phone = model.Phone,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                PostalCode = model.PostalCode,
                Country = "Bulgaria"
            };

            using var tx = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _orderRepository.AddAsync(order);

                foreach(var ci in cartItems)
                {
                    _cartRepository.Remove(ci);
                }

                await _unitOfWork.SaveChangesAsync();
                await tx.CommitAsync();

                return order.Id;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }
}
