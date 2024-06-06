using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using IT_Step_Final.Models;
using OnlineBooking.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OnlineBooking.Domain.Dtos;
using OnlineStore.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using OnlineBooking.Domain.Interfaces;

namespace IT_Step_Final.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IbookingRelate _bookService;

        public ManageUsersModel(UserManager<User> userManager, IbookingRelate bookService)
        {
            _userManager = userManager;
            _bookService = bookService;
        }

        public IList<UserViewModel> Users { get; set; }

        public async Task OnGetAsync()
        {
            var users = _userManager.Users.ToList();
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var bookings = await _bookService.GetUserByIdAsync(user.Id, new BookingModel() { UserID = user.Id });
                var userViewModel = new UserViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Bookings = bookings
                    
                };
                userViewModels.Add(userViewModel);
            }

            Users = userViewModels;
        }

        public async Task<IActionResult> OnPostDeleteAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToPage();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }

    public class UserViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<BookingModel> Bookings { get; set; }
        public IEnumerable<HotelModel> Hotel { get; set; }
    }
}
