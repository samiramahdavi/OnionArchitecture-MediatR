using Moq;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Contracts.ViewModel_DTO.Comment;
using OnionArchitecture.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnionArchitecture.XUnitTest.CommentTest
{
    /// <summary>
    /// simulate a data base
    /// </summary>
    public static class MockCommentRepository
    {
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var list = new List<Comment>()
            {
                new Comment{ Id = 1,Name="samira1",Family = "mahdavi1", EmailAddress="samiramahdavii@gmail.com1",Message = "hi new test1"},
                new Comment{ Id = 2,Name="samira2",Family = "mahdavi2", EmailAddress="samiramahdavii@gmail.com2",Message = "hi new test2"},
                new Comment{ Id = 3,Name="samira3",Family = "mahdavi3", EmailAddress="samiramahdavii@gmail.com3",Message = "hi new test3"},
                new Comment{ Id = 4,Name="samira4",Family = "mahdavi4", EmailAddress="samiramahdavii@gmail.com4",Message = "hi new test4"},
            };

            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(list);
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Comment>())).ReturnsAsync((Comment comment) =>
            {
                list.Add(comment);
                return comment;
            });
            //mockRepo.Setup(r=>r.Update(new Comment { Id=2,Name = "ali",Family="ahmadi",EmailAddress="test@gmail.com",Message="hi"}));

            mockRepo.Setup(r => r.Update(It.IsAny<Comment>())).Verifiable();

            return mockRepo;

        }
    }
}
