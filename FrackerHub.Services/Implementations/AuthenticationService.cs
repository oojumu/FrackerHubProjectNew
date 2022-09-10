using FrackerHub.Entities;
using FrackerHub.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrackerHub.Services.Implementations
{
    public enum NotificationType
    {
        Success, Error, Info
    }
    public class AuthenticationService : IAuthenticationService
    {
        protected SignInManager<User> _signinManager;
        protected UserManager<User>   _userManager;
        protected RoleManager<Role>   _roleManager;

        public AuthenticationService(SignInManager<User> signinManager, UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _signinManager = signinManager;
            _userManager   = userManager;
            _roleManager   = roleManager;
        }

        public int CountAllUsers()
        {
            int TotalUsers = 0;
            try
            {
                TotalUsers = _userManager.Users.Count();
            }
            catch (Exception ex)
            {
                // ex.Message;
                return TotalUsers;
            }

            return TotalUsers;
        }

        public User AuthenticateUser(string userName, string password)
        {
            var result = _signinManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false).Result;

            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(userName).Result;

                var roles = _userManager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();

                return user;

            }
            return null;

        }

        
               

        public User GetUser(string userName)
        {
            return _userManager.FindByNameAsync(userName).Result;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                 await _signinManager.SignOutAsync();
                 return true;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        //public string CreateUser(User user, string password)
        //{
        //    throw new NotImplementedException();
        //}

        public string CreateUser(User user, string password)
        {
            var result = _userManager.CreateAsync(user, password).Result;

            //result.
            string response = null;// result.toString();

            if (!result.Succeeded)
            {
                response = result.Errors.ToList()[0].Description.ToString();
            }
                
            if (result.Succeeded)
            {
                string role = "User";

                var res = _userManager.AddToRoleAsync(user, role).Result;
                if (res.Succeeded)
                {
                    return "";

                }
            }
            return response;// result[0].toString();

        }

        //public bool SignOut()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<bool> IAuthenticationService.SignOut()
        //{
        //    _signinManager.SignOutAsync();
        //}
    }
}
