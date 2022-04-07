using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Contracts.ViewModel_DTO.Comment
{
    public class CommentDto
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }

        public string Family { get; set; }

        public string EmailAddress { get; set; }

        public string Message { get; set; }
    }
}
