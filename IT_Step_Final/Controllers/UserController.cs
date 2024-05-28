/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;

namespace IT_Step_Final.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRelated userelated;

        public UserController(IUserRelated userelated)
        {
                this.userelated = userelated;
        }
        [AllowAnonymous]
        public IActionResult Index()//here  we  add sign in page
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserSignInModel signIn)
        {
           throw new NotImplementedException();//ther we  add sign in checking logic
        }

        public ActionResult CreateAsync()// action for view regisracia
        {
            return View();
        }

        [HttpPost]
        public  async Task CreateAsync([FromBody] UserModel entity)
        {
            await Task.Delay(500);
            throw new NotImplementedException();
        }


        [HttpDelete]
        [Route("{id:long}")]
        public Task DeleteAsync([FromRoute]string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("All")]
        public Task<ActionResult<UserModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("/{id:alpha}")]
        public Task<ActionResult<UserModel>> GetByIdAsync([FromRoute]string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult UpdateAsync()// action for view
        {
            return View();
        }

        [HttpPut]
        [Route("{id:alpha}")]
        public Task<ActionResult> UpdateAsync(string id,UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
*/