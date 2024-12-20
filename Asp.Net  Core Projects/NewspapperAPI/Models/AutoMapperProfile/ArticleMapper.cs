using AutoMapper;
using NewspapperAPI.Models.Entities.BlogEntities;
using NewspapperAPI.Models.ModelDto.BlogDto;

namespace NewspapperAPI.Models.AutoMapperProfile
{
    public class ArticleMapper : Profile
    {
        public ArticleMapper()
        {
            //CreateMap<Article, ArticleModelDto>()
            //    .ForMember(des => des.Body, opt => opt.MapFrom(src => $"{src.Content}")); 

            //CreateMap<ArticleModelDto, Article>()
            //    .ForMember(des => des.DatePosted, opt => opt.MapFrom(src => $"{src.CreatedAt}"));

            //CreateMap<Article, ArticleModelDto>()
            //    .ForMember(des => des.Title, opt => opt.MapFrom(src => $"{src.Title}"));

            //CreateMap<Article, ArticleModelDto>()
            //    .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => $"{src.DatePosted}"));
        }
    }
}
