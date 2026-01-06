using GrandLineAuto.Data.Models.CartEntities;
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
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CartService(ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Guid userId, Guid productId, int quantity)
        {
            var checkIfAvailable = await _cartRepository.All().FirstOrDefaultAsync(cr => cr.UserId == userId && cr.ProductId == productId);

            if (checkIfAvailable == null) 
            {
                await _cartRepository.AddAsync(new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            else
            {
                checkIfAvailable.Quantity += quantity;
                _cartRepository.Update(checkIfAvailable);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
