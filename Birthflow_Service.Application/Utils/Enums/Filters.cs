using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Application.Utils.Enums
{
    public class Filters
    {
        public enum ConditionTypeEnum
        {
            Equals = 1,
            NotEquals = 2,
            Contains = 3,
            GreaterThan = 4,
            GreaterThanOrEqual = 5,
            LessThan = 6,
            LessThanOrEqual = 7,
            In = 8
        }
    }
}
