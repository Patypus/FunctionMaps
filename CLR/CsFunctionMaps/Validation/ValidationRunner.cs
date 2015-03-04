using CsFunctionMaps.Resources;
using CsFunctionMaps.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFunctionMaps.Validator
{
    public class ValidationRunner
    {
        private readonly IDictionary<ValueTypes, Func<object, IValidationResult>> validationFunctions;

        public ValidationRunner()
        {
            validationFunctions = new Dictionary<ValueTypes, Func<object, IValidationResult>>
            {
                { ValueTypes.String, (value) => ValidationFunctions.ValidateStringValue(value) },
                { ValueTypes.Int, (value) => ValidationFunctions.ValidateIntObject(value) },
                { ValueTypes.Lattitude, (value) => ValidationFunctions.ValidateLattitude(value) },
                { ValueTypes.Longitude, (value) => ValidationFunctions.ValidateLongitude(value) }
            };
        }

        public IValidationResult ValidateValue(ValueTypes type, object value)
        {
            IValidationResult result;
            if (value != null && type != null)
            {
                result = validationFunctions.ContainsKey(type)
                            ? validationFunctions[type].Invoke(value)
                            : CreateUnableToValidateValueResult(type.ToString());
            }
            else
            {
                result = CreateNullValueValidationResult();
            }
            return result;
        }

        private IValidationResult CreateNullValueValidationResult()
        {
            return new ValidationResult(false, StringResources.CantValidateNullValue);
        }

        private IValidationResult CreateUnableToValidateValueResult(string typeThatCantBeValidated)
        {
            return new ValidationResult(false, string.Format(StringResources.UnableToValidate, typeThatCantBeValidated));
        }
    }
}
