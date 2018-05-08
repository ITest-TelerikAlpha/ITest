using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.Infrastructure.Providers;
using ITest.Models;
using ITest.Services.Data;
using ITest.Services.Data.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ITest.UnitTests.UserTetstService
{
    [TestClass]
    public class AssignTestToUserShould
    {
        private UserTestService userTestService;
        private Mock<IMappingProvider> mapperMock;
        private Mock<ISaver> saverMock;
        private Mock<IRepository<UserTest>> userTestRepositoryMock;
        private Mock<ITestService> testServiceMock;
        private Mock<IUserService> userServiceMock;
        private Mock<IAnswerService> answerServiceMock;
        private Mock<IUserAnswersService> userAnswersServiceMock;

        [TestInitialize]
        public void StartUp()
        {
            mapperMock = new Mock<IMappingProvider>();
            saverMock = new Mock<ISaver>();
            userTestRepositoryMock = new Mock<IRepository<UserTest>>();
            testServiceMock = new Mock<ITestService>();
            userServiceMock = new Mock<IUserService>();
            answerServiceMock = new Mock<IAnswerService>();
            userAnswersServiceMock = new Mock<IUserAnswersService>();

            userTestService = new UserTestService(userTestRepositoryMock.Object,
                testServiceMock.Object, userServiceMock.Object,
                saverMock.Object, userAnswersServiceMock.Object,
                mapperMock.Object, answerServiceMock.Object);
        }

        [TestMethod]
        public void ThrowArgumentNulException_IfTheTestIsNull()
        {
        }
    }
}
