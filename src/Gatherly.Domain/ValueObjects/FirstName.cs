
using Gatherly.Domain.Errors;
using Gatherly.Domain.Primitives;
using Gatherly.Domain.Shared;
using System.Reflection.Metadata;

namespace Gatherly.Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    private const int MaxLength = 50;
    private FirstName(string value)
    {
        Value = value;
    }
    public string Value { get;  }

    public static Result<FirstName> Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<FirstName>(ValueObjectErrors.FirstName.FirstNameEmpty);
        }
        if (firstName.Length > MaxLength)
        {
            return Result.Failure<FirstName>(ValueObjectErrors.FirstName.FirstNameTooLong);
        }
        return new FirstName(firstName);
}



    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

}
