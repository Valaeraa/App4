using App4.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App4.WebUI.Api
{
    public interface IUsersEndpoint
    {
        Task<IEnumerable<UserModel>> GetAll();
        Task<UserModel> GetById(int id);
        Task Update(int id, UserModel user);
        Task Create(UserModel user);
    }
}
