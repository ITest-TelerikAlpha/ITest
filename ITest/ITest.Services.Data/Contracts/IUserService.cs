using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Services.Data.Contracts
{
    public interface IUserService
    {
        string GetCurrentLoggedUser();
        string GetUserEmailById(string userId);
    }
}
