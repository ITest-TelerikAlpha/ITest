using ITest.Models;
using ITest.Services.Data.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ITest.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentLoggedUser()
        {
            return this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;       
        }
    }
}
