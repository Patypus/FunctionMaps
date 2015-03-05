using CsFunctionMaps.Validator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFunctionMaps.Validation
{
    /// <summary>
    /// Setup as a unit test to allow easy debugging and running!
    /// </summary>
    [TestFixture]
    public class ExampleRunningValidation
    {
        private ValidationRunner validator;

        [SetUpFixture]
        public void Setup()
        {
            //Setup the validation runner which creates its own map of validation functions.
            validator = new ValidationRunner();
        }

        [Test]
        public void RunExampleValidation()
        {
            var passingvalues = CreatePassingValuesDictionary();
            var failingValues = CreateFailingValuesDictionary();

            ValidateAll(passingvalues);
            ValidateAll(failingValues);
        }

        private void ValidateAll(IDictionary<ValueTypes, object> values)
        {
            foreach (var valuePair in values) 
            {
                validator.ValidateValue(valuePair.Key, valuePair.Value);
            }
        }

        private IDictionary<ValueTypes, object> CreatePassingValuesDictionary()
        {
            return new Dictionary<ValueTypes, object>
            {
                { ValueTypes.String, "This is valid" },
                { ValueTypes.Int, 12 },
                { ValueTypes.Lattitude, 25.00 },
                { ValueTypes.Longitude, 105.23 }
            };
        }

        private IDictionary<ValueTypes, object> CreateFailingValuesDictionary()
        {
            return new Dictionary<ValueTypes, object>
            {
                { ValueTypes.String, string.Empty },
                { ValueTypes.Int, -100 },
                { ValueTypes.Lattitude, -100.00 },
                { ValueTypes.Longitude, 4900.23 }
            };
        }
    }
}
