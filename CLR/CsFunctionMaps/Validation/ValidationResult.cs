using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFunctionMaps.Validation
{
    public class ValidationResult : IValidationResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public ValidationResult(bool result, string validationMessage = null)
        {
            Success = result;
            Message = validationMessage ?? string.Empty;
        }
    }
}