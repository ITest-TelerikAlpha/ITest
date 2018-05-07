using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITest.Data.Models;
using ITest.Services.Data;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ITest.UnitTests.AnswerService
{
    [TestClass]
    public class IsCorrectAnswerShould
    {
        [TestMethod]
        public void ReturnTrue_WhenTheAnswerIsCorrect()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var answerRepositoryMock = new Mock<IRepository<Answer>>();
            var questionRepositoryMock = new Mock<IRepository<Question>>();


            var answerService = new Services.Data.AnswerService(questionRepositoryMock.Object, answerRepositoryMock.Object, saverMock.Object, mapperMock.Object);

            var answers = new List<Answer>()
            {
                new Answer{Id = Guid.Parse("bb01cb4c-b260-45c7-9f43-4abc3338e211"),
                    Content = "Answer",
                    QuestionId = Guid.Parse("d987165b-3278-42d1-9918-834556989282"),
                    IsCorrect = true
                }
            };

            answerRepositoryMock.Setup(a => a.All).Returns(answers.AsQueryable());

            Assert.AreEqual(true, answerService.IsAnswerCorrect("bb01cb4c-b260-45c7-9f43-4abc3338e211"));
        }
        [TestMethod]
        public void ReturnFalse_WhenTheAnswerIsNotCorrect()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var answerRepositoryMock = new Mock<IRepository<Answer>>();
            var questionRepositoryMock = new Mock<IRepository<Question>>();


            var answerService = new Services.Data.AnswerService(questionRepositoryMock.Object, answerRepositoryMock.Object, saverMock.Object, mapperMock.Object);

            var answers = new List<Answer>()
            {
                new Answer{Id = Guid.Parse("bb01cb4c-b260-45c7-9f43-4abc3338e211"),
                    Content = "Answer",
                    QuestionId = Guid.Parse("d987165b-3278-42d1-9918-834556989282"),
                    IsCorrect = false
                }
            };

            answerRepositoryMock.Setup(a => a.All).Returns(answers.AsQueryable());

            Assert.AreEqual(false, answerService.IsAnswerCorrect("bb01cb4c-b260-45c7-9f43-4abc3338e211"));
        }
    }
}
