using System;
using System.Collections.Generic;

namespace data.Models.Context;

public partial class tbl_service_category
{
    public int id { get; set; }

    public string? category { get; set; }

    public virtual ICollection<tbl_service> tbl_services { get; set; } = new List<tbl_service>();
}
