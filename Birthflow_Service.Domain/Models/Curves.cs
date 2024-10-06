using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.Models
{
    public class Curves
    {
        public List<AlertCurve>? AlertCurve { get; set; }
        public List<AlertCurve>? newAlertCurve { get; set; }
    }
}
