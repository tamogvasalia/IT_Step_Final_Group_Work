using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Domain.Interfaces;

namespace IT_Step_Final.Controllers
{
    public class BookRelatedController : Controller
    {
        private readonly IbookingRelate bookrelate;

        public BookRelatedController(IbookingRelate bookrelate)
        {
                this.bookrelate = bookrelate;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
