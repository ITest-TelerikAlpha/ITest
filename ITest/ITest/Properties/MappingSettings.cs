using AutoMapper;
using ITest.Areas.Admin.Models;
using ITest.Areas.Admin.Models.AdminViewModels;
using ITest.Data.Models;
using ITest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITest.Properties
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            this.CreateMap<TestDTO, Test>(MemberList.Source);
            this.CreateMap<CategoryDTO, Category>(MemberList.Source);
            this.CreateMap<QuestionDTO, Question>(MemberList.Source);
            this.CreateMap<AnswerDTO, Answer>(MemberList.Source);


            //create test mappings
            this.CreateMap<CategoryViewModel, CategoryDTO>(MemberList.Source);
            this.CreateMap<CreateTestViewModel, TestDTO>(MemberList.Source);
            this.CreateMap<CreateQuestionViewModel, QuestionDTO>(MemberList.Source);
            this.CreateMap<CreateAnswerViewModel, AnswerDTO>(MemberList.Source);

        }
    }
}
