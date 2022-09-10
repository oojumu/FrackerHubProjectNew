using FrackerHub.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrackerHub.Repositories.Interfaces
{
    public interface IGenRepository
    {
        UserItem GetUserItemById(int Id);
    }
}
