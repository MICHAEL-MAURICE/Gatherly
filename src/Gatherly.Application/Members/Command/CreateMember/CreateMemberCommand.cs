using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherly.Application.Members.Command.CreateMember
{
    public sealed record CreateMemberCommand(string Email,string FirstName,string LastName ):IRequest;
    
}
