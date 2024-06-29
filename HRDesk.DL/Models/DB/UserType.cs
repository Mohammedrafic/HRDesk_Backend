using System;
using System.Collections.Generic;

namespace HRDesk.DL.Models.DB;

public partial class UserType
{
    public Guid UserTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
