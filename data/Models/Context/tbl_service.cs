using System;
using System.Collections.Generic;

namespace data.Models.Context;

public partial class tbl_service
{
    public int id { get; set; }

    public string? description { get; set; }

    public decimal? price { get; set; }

    public int? idEnterprice { get; set; }

    public int? idCategory { get; set; }

    public virtual tbl_service_category? idCategoryNavigation { get; set; }

    public virtual tbl_enterprice? idEnterpriceNavigation { get; set; }

    public virtual ICollection<tbl_washed> tbl_washeds { get; set; } = new List<tbl_washed>();
}
