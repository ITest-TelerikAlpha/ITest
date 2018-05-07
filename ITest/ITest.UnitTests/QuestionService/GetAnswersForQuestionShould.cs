using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITest.Data.Models;
using ITest.Data.Repository;
using ITest.Data.Saver;
using ITest.DTO;
using ITest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ITest.UnitTests.QuestionService
{
    [TestClass]
    public class GetAnswersForQuestionShould
    {
        [TestMethod]
        public void ReturnCollectionOfAnswers()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var questionRepositoryMock = new Mock<IRepository<Question>>();


            var questionService = new Services.Data.QuestionService(questionRepositoryMock.Object, saverMock.Object,
                    mapperMock.Object);
            var id = Guid.Parse("d987165b-3278-42d1-9918-834556989282");
            var answersDTOs = new List<AnswerDTO>()
            {
                new AnswerDTO
                {
                    Id = id,
                    Content = "Answer",
                    QuestionId = Guid.Parse("d987165b-3278-42d1-9918-834556989282"),
                    IsCorrect = true
                }
            };
            var answers = new List<Answer>()
            {
                new Answer
                {
                    Id = id,
                    Content = "Answer",
                    QuestionId = Guid.Parse("d987165b-3278-42d1-9918-834556989282"),
                    IsCorrect = true
                }
            };
            var questions = new List<Question>()
                {
                    new Question()
                    {
                        Id = id,
                        Answers =  answers
                    }
                };


            mapperMock.Setup(a => a.ProjectTo<AnswerDTO>(It.IsAny<IQueryable<Answer>>())).Returns(new List<AnswerDTO>(answersDTOs).AsQueryable);
            questionRepositoryMock.Setup(a => a.All).Returns(questions.AsQueryable);

            Assert.AreEqual(1, questionService.GetAnswersForQuestion(id.ToString())
                .Count());
        }
    }
}

