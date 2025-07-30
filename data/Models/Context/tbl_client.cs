using System;
using System.Collections.Generic;

namespace data.Models.Context;

public partial class tbl_client
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string? phone { get; set; }

    public string? email { get; set; }

    public string placa { get; set; } = null!;

    public virtual ICollection<tbl_washed> tbl_washeds { get; set; } = new List<tbl_washed>();
}
