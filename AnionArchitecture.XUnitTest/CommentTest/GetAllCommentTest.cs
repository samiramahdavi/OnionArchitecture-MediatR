using AutoMapper;
using Moq;
using OnionArchitecture.Contracts.ViewModel_DTO.Comment;
using OnionArchitecture.Repository.Repository.Interface;
using OnionArchitecture.Service.Features.CommentFeature.Queries;
using OnionArchitecture.Service.Mapper;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static OnionArchitecture.Service.Features.CommentFeature.Queries.GetAllCommentQuery;

namespace AnionArchitecture.XUnitTest.CommentTest
{
    public class GetAllCommentTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICommentRepository> _mockRepo;
        public GetAllCommentTest()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CommentMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task GetAllComment_Test()
        {
            var handler = new GetAllCommentQueryHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetAllCommentQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CommentDto>>();

            result.Count().ShouldBe(4);
        }
    }
}
