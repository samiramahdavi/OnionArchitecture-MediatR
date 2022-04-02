using OnionArchitecture.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class Comment: BaseEntity<Int64>
    {
        public string Name { get; set; }

        public string Family { get; set; }

        public string EmailAddress { get; set; }

        public string Message { get; set; }
    }
}
