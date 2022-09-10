using FrackerHub.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrackerHub.Services.Interfaces
{
    public interface IAdminService
    {
        //void GetUsers();
        void GetUser(int Id);
        IEnumerable<User> GetAllUsers();

        int GetAllUsersCount();

        IEnumerable<UserItem> GetTotalUploadedItemsCount();

        IEnumerable<UserItem> GetTotalUploadedItemsApprovedCount();

        IEnumerable<UserItem> GetTotalUploadedBorrowedItemsCount();


        Task<User> ApproveUserRegistration(string Id);

        UserItem FindUserItemForApproval(int Id);

        Task<UserItem> FindUserItemForApproval2(int Id);

        bool FindUserItemForApprovalNew(int Id);

        void DeclineUserRegistration(string Id);

        void BlockUser(int Id);

        void ApproveUserAsset(int Id);

        void RejectUserAsset(int Id);

        void GetTop5NewUploads();
        IEnumerable<UserItem> GetItemsPendingApproval();

        bool ApproveItemPendingApproval(UserItem userItem);

        Task <string> GetPhoneNumberofUserAsync(string email);




    }
}
