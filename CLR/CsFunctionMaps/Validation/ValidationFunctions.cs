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

            //These validation conditions could be anything, checking for poulation of the string is an example.
            var validationSuccess = !string.IsNullOrEmpty(castValue);
            var validationMessage = validationSuccess ? StringResources.ValidationPassed : StringResources.StringValueInvalid;

            return new ValidationResult(validationSuccess, validationMessage);
        }

        public static IValidationResult ValidateIntObject(object valueToValidate)
        {
            var castValue = (int)valueToValidate;

            var validationSuccess = castValue > 0;
            var validationMessage = validationSuccess ? StringResources.ValidationPassed : StringResources.IntegerValueInvalid;

            return new ValidationResult(validationSuccess, validationMessage);
        }

        //lat/longs?
    }
}
