using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDesk.Models.Response
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string? EmpName { get; set; }
        public int? Age { get; set; }
        public DateTime? Dob { get; set; }
        public long? PhoneNo { get; set; }
        public decimal? Salary { get; set; }
        public bool? IsStarred { get; set; }

    }
}
