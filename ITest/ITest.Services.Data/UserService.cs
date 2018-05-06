using ITest.Data.Repository;
using ITest.Models;
using ITest.Services.Data.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ITest.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IRepository<User> usersRepository;

        public UserService(IHttpContextAccessor httpContextAccessor, IRepository<User> usersRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.usersRepository = usersRepository;
        }

        public string GetCurrentLoggedUser()
        {
            return this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public string GetUserEmailById(string userId)
        {
            var user = this.usersRepository
                .All
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            var email = user.Email;
            return email;
        }
    }
}
