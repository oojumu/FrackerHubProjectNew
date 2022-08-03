using FrackerHub.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrackerHub.Services.Interfaces
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string userName, string password);
        String CreateUser(User user, string password);
        //bool SignOut();

        Task<bool> SignOut();

        User GetUser(string userName);

        int CountAllUsers();


    }
}
