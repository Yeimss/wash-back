using System;
using System.Collections.Generic;

namespace data.Models.Context;

public partial class tbl_user
{
    public int id { get; set; }

    public string document { get; set; } = null!;

    public string? name { get; set; }

    public string? lastName { get; set; }

    public string PasswordHash { get; set; } = null!;

    public int? idEnterprice { get; set; }

    public int? idRol { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual tbl_enterprice? idEnterpriceNavigation { get; set; }

    public virtual tbl_rol? idRolNavigation { get; set; }
}
