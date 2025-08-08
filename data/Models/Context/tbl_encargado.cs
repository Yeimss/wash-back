using System;
using System.Collections.Generic;

namespace data.Models.Context;

public partial class tbl_encargado
{
    public int id { get; set; }

    public string? name { get; set; }

    public int? idEnterprice { get; set; }

    public virtual tbl_enterprice? idEnterpriceNavigation { get; set; }

    public virtual ICollection<tbl_washed> tbl_washeds { get; set; } = new List<tbl_washed>();
}
