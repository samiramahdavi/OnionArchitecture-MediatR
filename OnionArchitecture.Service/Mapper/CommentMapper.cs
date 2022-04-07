using AutoMapper;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Contracts.ViewModel_DTO.Comment;

namespace OnionArchitecture.Service.Mapper
{
    public class CommentMapper : Profile
    {
        public CommentMapper()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
