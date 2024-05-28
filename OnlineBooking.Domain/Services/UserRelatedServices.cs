using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;
using OnlineStore.Core.Entities;
using System.Diagnostics;

namespace OnlineBooking.Domain.Services
{
    [DebuggerDisplay("User Related Implementation")]
    public class UserRelatedServices : BaseService, IUserRelated
    {

        private  UserManager<User> Usermanager;
        private  SignInManager<User> signInManage;
        public UserRelatedServices(IMapper map, UserManager<User> Usermanager, SignInManager<User> signInManage) : base(map)
        {
            this.Usermanager = Usermanager;
            this.signInManage = signInManage;
        }

        #region Registration
        public async Task<IdentityResult> Registraction(UserModel model)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(model, nameof(model));
                if(string.IsNullOrEmpty(model.Email)||string.IsNullOrEmpty(model.UserName)||string.IsNullOrEmpty(model.FirstName)
                    ||string.IsNullOrEmpty(model.LastName)) 
                {
                    throw new ArgumentException("Arguments can not be null");
                }
                var user=map.Map<User>(model);
                if(user!=null)
                {
                    var res=await Usermanager.CreateAsync(user, model.Password);

                    return res;
                }
                throw new ArgumentException(" Registration was unsuccesfull");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region SignIn
        public async Task<SignInResult> signIn(UserSignInModel model)
        {
            try
            {
                var res = await Usermanager.FindByNameAsync(model.UserName);
                if (res is not null)
                {
                    var signin = await signInManage.CheckPasswordSignInAsync(res, model.Password, true);

                    if (signin is not null)
                    {
                        return signin;
                    }
                }
                throw new ArgumentException("No Such User exist");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Signout
        public async Task SignOut()
        {
           await signInManage.SignOutAsync();
        }
        #endregion
    }
}
