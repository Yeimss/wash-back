using System;
using System.Collections.Generic;

namespace data.Models.Context;

public partial class tbl_rol
{
    public int id { get; set; }

    public string? rol { get; set; }

    public virtual ICollection<tbl_user> tbl_users { get; set; } = new List<tbl_user>();
}
