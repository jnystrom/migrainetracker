using Gazallion.MigraineManager.Common.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazallion.MigraineManager.Client.Common.Service.I
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int userId);


    }
}
