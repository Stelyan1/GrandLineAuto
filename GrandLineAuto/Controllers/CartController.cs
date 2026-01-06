using GrandLineAuto.Data.Models.UserEntities;
using GrandLineAuto.Infrastructure.Repositories.Purchasing.Interfaces;
using GrandLineAuto.Infrastructure.Services.Purchasing.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartService cartService, ICartRepository cartRepository, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            var items = await _cartRepository.All()
                .Where(c => c.UserId == userId).Include(c => c.Product).OrderByDescending(c => c.CreatedOnUtc).ToListAsync();

            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Guid productId, int quantity = 1)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            await _cartService.AddAsync(userId, productId, quantity);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Increase(Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            var item = await _cartRepository.All().FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (item == null) return NotFound();

            item.Quantity += 1;
            _cartRepository.Update(item);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decrease(Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            var item = await _cartRepository.All().FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (item == null) return NotFound();

            item.Quantity -= 1;
            if (item.Quantity <= 0) _cartRepository.Remove(item);
            else _cartRepository.Update(item);

            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid id)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            var item = await _cartRepository.All().FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (item == null) return NotFound();

            _cartRepository.Remove(item);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User)!);

            var items = await _cartRepository.All()
                .Where(c => c.UserId == userId)
                .ToListAsync();

            foreach (var i in items) _cartRepository.Remove(i);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
