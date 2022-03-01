using EPhoneAPI.Entities;
using EPhoneAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EPhoneAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EPhoneShopDBContext _context;

        public UserRepository(EPhoneShopDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IQueryable<User> GetAllUsers()
        {
            return _context.Set<User>().AsNoTracking();
        }

        Expression<Func<User, bool>> FilterByAccountNumber(int AccountNumber)
        {
            return p => p.AccountNumber == AccountNumber;
        }

        public IQueryable<User> GetUser(int AccountNumber)
        {
            return _context.Set<User>().Where(FilterByAccountNumber(AccountNumber)).AsNoTracking();
        }

        Expression<Func<User, bool>> FilterByUserName(string firstName)
        {
            return p => p.FirstName == firstName;
        }

        public IQueryable<User> GetUserByName(string firstname)
        {
            return _context.Set<User>().Where(FilterByUserName(firstname)).AsNoTracking();
        }

        public void CreateUser(User user)
        {
            _context.Set<User>().Add(user);
        }
        public void UpdateUser(User user)
        {
            _context.Set<User>().Update(user);
        }
        public void DeleteUser(int AccountNumber)
        {
            _context.Set<User>().Remove((EPhoneAPI.Entities.User)GetUser(AccountNumber));
        }
    }
}
