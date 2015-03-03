using CsFunctionMaps.Resources;
using CsFunctionMaps.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFunctionMaps.Validator
{
    public class Validator
    {
        private readonly IDictionary<ValueTypes, Func<object, IValidationResult>> validationFunctions;

        public Validator()
        {
            validationFunctions = new Dictionary<ValueTypes, Func<object, IValidationResult>>
            {
                { ValueTypes.String, (value) => ValidationFunctions.ValidateStringValue(value) },
                { ValueTypes.Int, (value) => ValidationFunctions.ValidateIntObject(value) },
                { ValueTypes.Lattitude, (value) => ValidationFunctions.ValidateLattitude(value) },
                { ValueTypes.Longitude, (value) => ValidationFunctions.ValidateLongitude(value) }
            };
        }

        public IValidationResult ValidateValue(Tuple<ValueTypes, object> valueDetails)
        {
            IValidationResult result;
            if (valueDetails != null)
            {
                result = validationFunctions.ContainsKey(valueDetails.Item1)
                            ? validationFunctions[valueDetails.Item1].Invoke(valueDetails.Item2)
                            : CreateUnableToValidateValueResult(valueDetails.Item1.ToString());
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
