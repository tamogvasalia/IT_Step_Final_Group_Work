using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;
using OnlineStore.Core.Entities;

namespace IT_Step_Final.Controllers
{
    public class BookRelatedController : Controller
    {
        private readonly IbookingRelate bookrelate;
        private readonly UserManager<User> _userManager;
        // need to add : add booking, delete booking, get booking by id. update booking.
        public BookRelatedController(IbookingRelate bookrelate, UserManager<User> userManager)
        {
            this.bookrelate = bookrelate;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var identity = new BookingModel { UserID = user.Id };
            var bookings = await bookrelate.GetAllAsync(identity);
            return View(bookings);
        }
    }
}
