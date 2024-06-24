using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Birthflow_Application.Utils.Enums.Filters;

namespace Birthflow_Application.Utils
{
    [DataContract]
    public class FindExpression
    {
        [DataMember]
        public List<SearchCriteria> SearchParameters { get; set; } = new List<SearchCriteria>();

        [DataMember]
        public int PageNumber { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public bool OrderByDescending { get; set; }

        public int PageNumberOrDefault
        {
            get
            {
                if (PageNumber <= 0)
                {
                    return 1;
                }
                return PageNumber;
            }
        }

        public int PageSizeOrDefault
        {
            get
            {
                if (PageSize <= 0)
                {
                    return int.MaxValue;
                }
                return PageSize;
            }
        }
    }

    [DataContract]
    public class SearchCriteria
    {
        [DataMember]
        public string Criteria { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public ConditionTypeEnum Condition { get; set; }
    }
}
