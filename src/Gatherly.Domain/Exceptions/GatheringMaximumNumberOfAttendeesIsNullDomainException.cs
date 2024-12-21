

namespace Gatherly.Domain.Exceptions;

public sealed class GatheringMaximumNumberOfAttendeesIsNullDomainException:DomainException
{
    public GatheringMaximumNumberOfAttendeesIsNullDomainException( string Message):base(Message)
    {
            
    }
}
