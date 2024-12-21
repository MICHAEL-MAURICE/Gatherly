

using Gatherly.Domain.Primitives;

namespace Gatherly.Domain.Errors;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id) : base(id)
    {
    }
}
