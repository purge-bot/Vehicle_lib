using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_lib
{
    class VehicleParamOutOfRange : ArgumentOutOfRangeException
    {
        public VehicleParamOutOfRange(string paramName, object actualValue, string message) : base(paramName, actualValue, message)
        {

        }
    }
}
