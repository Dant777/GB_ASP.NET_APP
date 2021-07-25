using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Validation.Interfaces;

namespace BusinessLogicLayer.Validation.Operations
{
    public sealed class OperationFailure : IOperationFailure
    {

        public OperationFailure()
        {
            
        }
        public OperationFailure(string propertyName, string description, string code)
        {
            PropertyName = propertyName;
            Description = description;
            Code = code;
        }

        public string PropertyName { get;  }
        public string Description { get;  }
        public string Code { get;  }
    }
}