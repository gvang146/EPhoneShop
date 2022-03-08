using System.Collections.Generic;
using System.Threading.Tasks;
//using Core.Entities;
using EPhoneApi.Models;

namespace EPhoneApi.Repositories
{
    public interface IContactRepository
    {
        Task<Home> AddContact(); //async method
    }
}
