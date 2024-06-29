using System;
using System.Collections.Generic;

namespace HRDesk.DL.Models.DB;

public partial class User
{
    public Guid UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long PhoneNo { get; set; }

    public Guid? UserTypeId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? CreatedBy { get; set; }

    public string? UserName { get; set; }

    public virtual UserType? UserType { get; set; }
}
