using EPhoneAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPhoneAPI.Repositories
{
    public interface IPhoneRepository
    {
        IQueryable<Phone> GetAllPhones();
        IQueryable<Phone> GetPhoneByModel(int modelNumber);
        IQueryable<Phone> GetPhonesByBrand(string brand);
        IQueryable<Phone> GetPhonesByColor(string color);
        IQueryable<Phone> GetPhonesByFeatures(string features);
        IQueryable<Phone> GetPhonesBySpeed(string speed);

        void CreatePhone(Phone phone);
        void UpdatePhone(Phone phone);
        void DeletePhone(int modelNumber);
    }
}
