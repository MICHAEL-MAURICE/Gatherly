using Gatherly.Application.Abstractions;
using Gatherly.Domain.Enums;
using Gatherly.Domain.Repositories;
using MediatR;

namespace Gatherly.Application.Invitations.Commands.AcceptInvitation;

internal sealed class AcceptInvitationCommandHandler : IRequestHandler<AcceptInvitationCommand>
{
    private readonly IInvitationRepository _invitationRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IGatheringRepository _gatheringRepository;
    private readonly IAttendeeRepository _attendeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public AcceptInvitationCommandHandler(
        IInvitationRepository invitationRepository,
        IMemberRepository memberRepository,
        IGatheringRepository gatheringRepository,
        IAttendeeRepository attendeeRepository,
        IUnitOfWork unitOfWork,
        IEmailService emailService)
    {
        _invitationRepository = invitationRepository;
        _memberRepository = memberRepository;
        _gatheringRepository = gatheringRepository;
        _attendeeRepository = attendeeRepository;
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task<Unit> Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
    {
       
        var gathering = await _gatheringRepository
            .GetByIdWithCreatorAsync(request.GatheringId, cancellationToken);

        if ( gathering is null)
        {
            return Unit.Value;
        }
        var invitation = gathering.Invitations.FirstOrDefault(i=>i.Id==request.InvitationId);

        if (invitation is null || invitation.Status != InvitationStatus.Pending)
        {
            return Unit.Value;
        }

       // var member = await _memberRepository.GetByIdAsync(invitation.MemberId, cancellationToken);


        var attendee = gathering.AcceptInvitation(invitation);

        if (attendee is not null)
        {
            _attendeeRepository.Add(attendee);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

     

        return Unit.Value;
    }
}