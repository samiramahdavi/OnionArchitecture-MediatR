using AutoMapper;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Infrastructure.ViewModel_DTO.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
