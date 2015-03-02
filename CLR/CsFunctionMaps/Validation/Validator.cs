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
        private readonly IDictionary<Type, Func<object, IValidationResult>> validationFunctions;

        public Validator()
        {
            validationFunctions = new Dictionary<Type, Func<object, IValidationResult>>
            {
                { typeof(string), (value) => ValidationFunctions.ValidateStringValue(value) },
                { typeof(int), (value) => ValidationFunctions.ValidateIntObject(value) }
            };
        }

        public IValidationResult ValidateValue(object value)
        {
            IValidationResult result;
            if (value != null)
            {
                result = validationFunctions.ContainsKey(value.GetType()) 
                            ? validationFunctions[value.GetType()].Invoke(value)
                            : CreateUnableToValidateValueResult(value.GetType().Name);
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
