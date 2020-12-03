using FluentValidation.Results;
using System.Collections.Generic;
using System.Text;

namespace TestServer.Core.Extensions
{
    public static class FluentValidationExtensions
    {
        public static string ToMessage(this IList<ValidationFailure> errors)
        {
            var result = new StringBuilder();
            foreach (var error in errors)
            {
                result.AppendLine(error.ErrorMessage);
            }
            return result.ToString();
        }
    }
}
