using GrandLineAuto.Data;
using GrandLineAuto.Data.Models.OrderEntities.Enums;
using GrandLineAuto.Data.Models.UserEntities;
using GrandLineAuto.Infrastructure.DTO_s.OrderDTO_s;
using GrandLineAuto.Infrastructure.Services.Purchasing.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly GrandLineAutoDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(IOrderService orderService, GrandLineAutoDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Checkout()
            => View(new CheckoutVM());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            try
            {
                var orderId = await _orderService.CheckoutAsync(userId, model);

                if (model.PaymentMethod == PaymentMethod.Card)
                {
                    return RedirectToAction(nameof(Pay), new { id = orderId });
                }

                //Paypal coming soon

                //if (model.PaymentMethod == PaymentMethod.Paypal)
                //{
                //    return RedirectToAction(nameof(Pay), new { id =  orderId });
                //}

                return RedirectToAction(nameof(Success), new { id = orderId });
            }
            catch (InvalidOperationException ex) // Cart empty
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Pay(Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

            if (order == null) return NotFound();

            if (order.PaymentMethod != PaymentMethod.Card || order.PaymentStatus != PaymentStatus.Pending)
                return RedirectToAction(nameof(Details), new { id });

            return View(id);
        }

        [HttpGet]
        public async Task<IActionResult> Success(Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            var order = await _dbContext.Orders
                .Include(o => o.Items)
                .Include(o => o.ShippingAddress)
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            var orders = await _dbContext.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedOnUtc)
                .ToListAsync();

            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            var order = await _dbContext.Orders
                .Include(o => o.Items)
                .Include(o => o.ShippingAddress)
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

            if (order == null) return NotFound();

            return View(order);
        }
    }
}
