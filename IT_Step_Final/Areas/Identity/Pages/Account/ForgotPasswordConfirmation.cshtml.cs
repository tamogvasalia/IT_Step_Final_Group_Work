
#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Step_Final.Areas.Identity.Pages.Account
{

    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {

        public void OnGet()
        {
        }
    }
}
