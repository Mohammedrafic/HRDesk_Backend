using System;
using System.Collections.Generic;

namespace HRDesk.DL.Models.DB;

public partial class Employee
{
    public int Id { get; set; }

    public string? EmpName { get; set; }

    public int? Age { get; set; }

    public DateTime? Dob { get; set; }

    public long? PhoneNo { get; set; }

    public decimal? Salary { get; set; }

    public bool? IsStarred { get; set; }
}
