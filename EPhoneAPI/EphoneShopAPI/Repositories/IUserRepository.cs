using EPhoneAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace EPhoneAPI.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
        IQueryable<User> GetUser(int AccountNumber);
        IQueryable<User> GetUserByName(string firstName);

        void CreateUser(User User);
        void UpdateUser(User User);
        void DeleteUser(int AccountNumber);
    }
}
