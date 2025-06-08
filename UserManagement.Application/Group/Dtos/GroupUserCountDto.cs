using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Group.Dtos
{
    public class GroupUserCountDto : IRequest<List<GroupUserCountDto>>
    {
        public string GroupName { get; set; }
        public int UserCount { get; set; }
    }
}
