using FrackerHub.Entities;
using FrackerHub.Repositories;
using FrackerHub.Repositories.Interfaces;
using FrackerHub.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FrackerHub.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Item> _itemRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<ItemType> _itemTypeRepo;
        private readonly IRepository<UserItem> _userItemRepo;
        private readonly IRepository<UserItem> _frackedItemRepo;

        protected UserManager<User> _userManager;
//        protected UserManager<User> _userManager;

        //private AppDbContext appContext
        //{
        //    get
        //    {

        //        return _dbContext as AppDbContext;
        //    }

        //}
        public AdminService(UserManager<User> userManager, IRepository<UserItem> frackedItemRepo, IRepository<UserItem> userItemRepo, IRepository<Item> itemRepo, IRepository<Category> categoryRepo, IRepository<ItemType> itemTypeRepo)
        {
            _itemRepo = itemRepo;
            _categoryRepo = categoryRepo;
            _itemTypeRepo = itemTypeRepo;
            _userManager = userManager;
            _userItemRepo = userItemRepo;
            _frackedItemRepo = frackedItemRepo;
        }

        public bool ApproveItemPendingApproval(UserItem userItem)
        {
            _userItemRepo.Update(userItem);
            _userItemRepo.SaveChanges();
            return true;
        }

        public void ApproveUserAsset(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> ApproveUserRegistration(string Id)
        {

            //return  await _userManager.FindByIdAsync(Id);

            User result = await _userManager.FindByIdAsync(Id);

            if (result.Approved == 0)
            {
                result.Approved = 1;
                //User result2 = new User
                //{
                //    Id = result.Id,
                //    Approved = 1
                //};

                await _userManager.UpdateAsync(result);
                return result;
            }

            //_dbcontext
            return result;
        }

        public void BlockUser(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeclineUserRegistration(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeclineUserRegistration(string Id)
        {
            throw new NotImplementedException();
        }

        public  UserItem FindUserItemForApproval(int Id)
        {
            var sx =   _userItemRepo.Find(Id);
            UserItem dx = new UserItem
            {
                Id = sx.Id,
                //Name = userItem.Name,
                //UnitPrice = userItem.UnitPrice,
                //Description = userItem.Description,
                //ImageUrl = userItem.ImageUrl,
                Status = 4
            };

            return _userItemRepo.Find(Id);
        }

        public Task<UserItem> FindUserItemForApproval2(int Id)
        {
            throw new NotImplementedException();
        }

        public bool FindUserItemForApprovalNew(int Id)
        {
            bool flag = false;
            var sx = _userItemRepo.Find(Id);
            UserItem dx = new UserItem
            {
                Id = sx.Id,
                //Name = userItem.Name,
                //UnitPrice = userItem.UnitPrice,
                //Description = userItem.Description,
                //ImageUrl = userItem.ImageUrl,
                Status = 4
            };

            _userItemRepo.Update(dx);
            return flag;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userManager.Users;
        }

        public int GetAllUsersCount()
        {
            return 1;// _userManager.Users;
        }

        public IEnumerable<UserItem> GetItemsPendingApproval()
        {

            return _userItemRepo.GetAll();
        }

        public async Task<string> GetPhoneNumberofUserAsync(string email)
        {
            throw new NotImplementedException();
            //User result = await _userManager.FindByIdAsync(Id);

        }

        //public UserItem GetItemsPendingApproval()
        //{
        //        return _userItemRepo.GetAll();
        //}

        //public IEnumerable<UserItem> GetItemsPendingApproval()
        //{
        //    return _itemRepo.GetAll();
        //}

        public void GetTop5NewUploads(Item item)
        {
            _itemRepo.Add(item);
            //_itemRepo.        
        }

        public void GetTop5NewUploads()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserItem> GetTotalUploadedBorrowedItemsCount()
        {
            return _frackedItemRepo.GetAll();
        }

        public IEnumerable<UserItem> GetTotalUploadedItemsApprovedCount()
        {
            return _userItemRepo.GetAll();
        }

        public IEnumerable<UserItem> GetTotalUploadedItemsCount()
        {
            return _userItemRepo.GetAll();
        }

        public void GetUsers()
        {

            throw new NotImplementedException();
        }

        public void RejectUserAsset(int Id)
        {
            throw new NotImplementedException();
        }

        void IAdminService.GetUser(int Id)
        {
            throw new NotImplementedException();
        }

      
    }
}
