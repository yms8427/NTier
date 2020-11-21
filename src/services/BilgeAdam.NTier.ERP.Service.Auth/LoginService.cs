using BilgeAdam.NTier.ERP.Common;
using BilgeAdam.NTier.ERP.Data.Access;
using BilgeAdam.NTier.ERP.Data.Entities;
using BilgeAdam.NTier.ERP.Dto.Users;
using System;
using System.Linq;

namespace BilgeAdam.NTier.ERP.Service.Auth
{
    public class LoginService
    {
        private Repository<User> repo;

        public LoginService()
        {
            repo = new Repository<User>();
        }

        public LoginResultDto Login(string userName, string password)
        {
            var hash = password.Hash();
            var result = repo.FirstOrDefault(u => u.UserName == userName && u.Password == hash && u.IsActive == true);
            if (result != null)
            {
                result.LastLoginDate = DateTime.Now;
                repo.Save();
                return new LoginResultDto
                {
                    DisplayName = result.DisplayName
                };
            }
            return null;
        }

        public bool Register(string userName, string password)
        {
            var existingUser = repo.FirstOrDefault(u => u.UserName == userName);
            if (existingUser != null)
            {
                return false;
            }

            var @new = new User
            {
                UserName = userName,
                Password = password.Hash(),
                DisplayName = userName,
                IsActive = false
            };
            repo.Add(@new);
            return repo.Save() > 0;
        }
    }
}