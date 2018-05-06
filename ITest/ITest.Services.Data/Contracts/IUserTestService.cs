using ITest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITest.Services.Data.Contracts
{
    public interface IUserTestService
    {
        bool CheckIfUserHasAssignedTest(string category);

        void AssignTestToUser(string category);

        void Publish(UserTestDTO dto);

        UserTestDTO GetAssignedTestWithCategory(string category);

       IQueryable<UserTestDTO> GetAllTestScoresWithUsers();
    }
}
