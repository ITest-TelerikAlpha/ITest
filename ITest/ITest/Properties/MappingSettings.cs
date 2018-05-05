using AutoMapper;
using ITest.Areas.Admin.Models;
using ITest.Areas.Admin.Models.AdminViewModels;
using ITest.Areas.User.Models;
using ITest.Areas.User.Models.HomeViewModels;
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
            this.CreateMap<TestDTO, Test>(MemberList.Source)
                .ForMember(t => t.Questions, o => o.MapFrom(x => x.Questions))
                .ReverseMap();

            this.CreateMap<CategoryDTO, Category>(MemberList.Source);

            this.CreateMap<QuestionDTO, Question>(MemberList.Source)
                .ForMember(q => q.Answers, o => o.MapFrom(q => q.Answers))
                .ReverseMap();

            this.CreateMap<AnswerDTO, Answer>(MemberList.Source)
                .ForMember(a => a.Content, o => o.MapFrom(a => a.Content))
                .ForMember(a => a.IsCorrect, o => o.MapFrom(a => a.IsCorrect))
                .ReverseMap();

            this.CreateMap<UserTestDTO, UserTest>(MemberList.Source).MaxDepth(3);



            //create test mappings
            this.CreateMap<CategoryViewModel, CategoryDTO>(MemberList.Source);
            this.CreateMap<CreateTestViewModel, TestDTO>(MemberList.Source);
            this.CreateMap<CreateQuestionViewModel, QuestionDTO>(MemberList.Source);
            this.CreateMap<CreateAnswerViewModel, AnswerDTO>(MemberList.Source);
            this.CreateMap<TestDTO, CreateTestViewModel>(MemberList.Source);

            this.CreateMap<CreateTestViewModel, TestDTO>(MemberList.Source)
              .ForMember(q => q.Questions, o => o.MapFrom(a => a.Questions))
              .ReverseMap();

            this.CreateMap<CreateQuestionViewModel, QuestionDTO>(MemberList.Source)
                .ForMember(a => a.Answers, o => o.MapFrom(q => q.Answers))
                .ForMember(a => a.Content, o => o.MapFrom(q => q.Content))
                .ReverseMap();

            this.CreateMap<CreateAnswerViewModel, AnswerDTO>(MemberList.Source)
               .ForMember(a => a.Content, o => o.MapFrom(x => x.Content))
               .ReverseMap();

            //take test mappings
            this.CreateMap<TakeTestViewModel, TestDTO>(MemberList.Source)
                .ForMember(q => q.Questions, o => o.MapFrom(a => a.Questions))
                .ReverseMap();

            this.CreateMap<QuestionViewModel, QuestionDTO>(MemberList.Source)
                .ForMember(a => a.Answers, o => o.MapFrom(q => q.Answers))
                .ForMember(a => a.Content, o => o.MapFrom(q => q.Description))
                .ReverseMap();

            this.CreateMap<AnswerViewModel, AnswerDTO>(MemberList.Source)
                .ForMember(a => a.Content, o => o.MapFrom(x => x.Description))
                .ReverseMap();

            //user mappings
            this.CreateMap<TestCategoryViewModel, CategoryDTO>(MemberList.Destination);
        }
    }
}
