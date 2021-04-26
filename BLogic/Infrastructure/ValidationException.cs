using System;
using System.Collections.Generic;
using System.Text;

namespace BLogic.Infrastructure
{
    class ValidationException :Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
