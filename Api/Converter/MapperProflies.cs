using Api.Dto;
using AutoMapper;
using Core.Models;

namespace Api.Converter
{
    public class MapperProflies : Profile
    {
        public MapperProflies()
        {
            CreateMap<Quiz, QuizDto>().ReverseMap();
            CreateMap<Round, RoundDto>().ReverseMap();
            CreateMap<Question, QuestionDto>()
                .ForMember(
                    dest => dest.CorrectAnswer,
                    opt => opt.MapFrom(src => src.Answers.Split(';', StringSplitOptions.None).ElementAtOrDefault(src.AnswerIndex))
                ).ForMember(
                    dest => dest.Answers,
                    opt => opt.MapFrom(src => src.Answers.Split(';', StringSplitOptions.None))
                );
            CreateMap<QuestionDto, Question>()
                .ForMember(
                    dest => dest.Answers,
                    opt => opt.MapFrom(src => String.Join(';', src.Answers))
                ).ForMember(
                    dest => dest.AnswerIndex,
                    opt => opt.MapFrom(src => src.Answers.IndexOf(src.CorrectAnswer))
                );
        }
    }
}
