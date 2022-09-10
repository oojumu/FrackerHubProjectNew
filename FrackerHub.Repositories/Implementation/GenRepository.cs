using FrackerHub.Entities;
using FrackerHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrackerHub.Repositories.Implementation
{
    public class GenRepository :  IGenRepository
    {
        protected DbContext _dbContext;

        //private AppDbContext appDbContext
        //{
        //    get
        //    {

        //        return _dbContext as AppDbContext;
        //    }
        //}

        public GenRepository(DbContext dbContext)//: base(dbContext)
        {
            _dbContext = dbContext;
        }
        public UserItem GetUserItemById(int Id)
        {
            throw new NotImplementedException();
        }

        public void TrySmthg()
        {
            //_dbContext.ContextId.Lease.


        }
    }
}
