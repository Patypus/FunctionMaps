using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFunctionMaps.Validation
{
    public interface IValidationResult
    {
        public bool Success { get; }
        public string Message { get; }
    }
}
