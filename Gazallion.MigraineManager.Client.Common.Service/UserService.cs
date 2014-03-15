using Gazallion.MigraineManager.Client.Common.Service.I;
using Gazallion.MigraineManager.Common.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazallion.MigraineManager.Client.Common.Service
{
    public class UserService: IUserService
    {
        private const string USER_SERVICE_URL = "http://john-win8pc/MigraineManager/api/user/";
        

        public async Task<UserDto> GetUser(int userId)
        {
            var user = await ServiceHelper.GetDataAsync<UserDto>(string.Format(USER_SERVICE_URL + "{0}", userId));
            return user;
        }
    }
}
