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
    public class PhoneRepository : IPhoneRepository
    {
        private readonly EPhoneShopDBContext _context;

        public PhoneRepository(EPhoneShopDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IQueryable<Phone> GetAllPhones()
        {
            return _context.Set<Phone>().AsNoTracking();
        }

        Expression<Func<Phone, bool>> FilterByModelNumber(int modelNumber)
        {
            return p => p.modelNumber == modelNumber;
        }

        public IQueryable<Phone> GetPhoneByModel(int modelNumber)
        {
            return _context.Set<Phone>().Where(FilterByModelNumber(modelNumber)).AsNoTracking();
        }

        Expression<Func<Phone, bool>> FilterByBrand(string brand)
        {
            return p => p.brand == brand;
        }

        public IQueryable<Phone> GetPhonesByBrand(string brand)
        {
            return _context.Set<Phone>().Where(FilterByBrand(brand)).AsNoTracking();
        }

        Expression<Func<Phone, bool>> FilterByColor(string color)
        {
            return p => p.color == color;
        }

        public IQueryable<Phone> GetPhonesByColor(string color)
        {
            return _context.Set<Phone>().Where(FilterByColor(color)).AsNoTracking();
        }

        Expression<Func<Phone, bool>> FilterByFeatures(string features)
        {
            return p => p.features == features;
        }

        public IQueryable<Phone> GetPhonesByFeatures(string features)
        {
            return _context.Set<Phone>().Where(FilterByFeatures(features)).AsNoTracking();
        }

        Expression<Func<Phone, bool>> FilterBySpeed(string speed)
        {
            return p => p.speed == speed;
        }

        public IQueryable<Phone> GetPhonesBySpeed(string speed)
        {
            return _context.Set<Phone>().Where(FilterBySpeed(speed)).AsNoTracking();
        }

        public void CreatePhone(Phone phone)
        {
            _context.Set<Phone>().Add(phone);
        }
        public void UpdatePhone(Phone phone)
        {
            _context.Set<Phone>().Update(phone);
        }
        public void DeletePhone(int ModelNumber)
        {
            _context.Set<Phone>().Remove((EPhoneAPI.Entities.Phone)GetPhoneByModel(ModelNumber));
        }
    }
}