using CsFunctionMaps.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFunctionMaps.Validation
{
    public static class ValidationFunctions
    {
        public static IValidationResult ValidateStringValue(object valueToValidate)
        {
            var castValue = (string)valueToValidate;

            var validationSuccess = !string.IsNullOrEmpty(castValue);
            var validationMessage = validationSuccess ? StringResources.ValidationPassed : StringResources.StringValueInvalid;

            return new ValidationResult(validationSuccess, validationMessage);
        }
    }
}
