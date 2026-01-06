using GrandLineAuto.Data;
using GrandLineAuto.Data.Models.OrderEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Areas.Admin.Controllers
{
    public class OrdersController : AdminBaseController
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public OrdersController(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _dbContext.Orders
                .Include(o => o.ShippingAddress)
                .OrderByDescending(o => o.CreatedOnUtc)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var order = await _dbContext.Orders
                .Include(o => o.Items)
                .Include(o => o.ShippingAddress)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetStatus(Guid id, OrderStatus status)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return NotFound();

            order.Status = status;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
