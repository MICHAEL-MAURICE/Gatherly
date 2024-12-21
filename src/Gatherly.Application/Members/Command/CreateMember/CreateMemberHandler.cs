using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;
using Gatherly.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherly.Application.Members.Command.CreateMember
{
    internal sealed class CreateMemberHandler : IRequestHandler<CreateMemberCommand>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberHandler( IMemberRepository memberRepository,IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;   
        }

        public async Task<Unit> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var FirstNameResult = FirstName.Create(request.FirstName);
            if (FirstNameResult.IsFailure)
            {
                //Log Error 
                return Unit.Value;
            }


            var Member= new Member(Guid.NewGuid(), FirstNameResult.Value, request.LastName,request.Email);
            _memberRepository.Add(Member);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
