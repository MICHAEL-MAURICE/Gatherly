using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherly.Domain.Errors
{
    public static class ValueObjectErrors
    {
        public static class FirstName
        {
            public static readonly Error FirstNameEmpty = new Error(
            "FirstName. Empty",
            "First name is empty.");

            public static readonly Error FirstNameTooLong = new Error(
            "FirstName. TooLong",
            "First name is too long.");
        }


    }
}
