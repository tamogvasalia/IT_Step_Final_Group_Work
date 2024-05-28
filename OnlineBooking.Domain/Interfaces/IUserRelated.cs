using Microsoft.AspNetCore.Identity;
using OnlineBooking.Domain.Dtos;

namespace OnlineBooking.Domain.Interfaces
{
    public interface IUserRelated
    {
        Task<SignInResult> signIn(UserSignInModel model);
        Task<IdentityResult> Registraction(UserModel model);
        Task SignOut();
    }
}
