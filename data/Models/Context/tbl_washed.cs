using System;
using System.Collections.Generic;

namespace data.Models.Context;

public partial class tbl_washed
{
    public int id { get; set; }

    public int? idClient { get; set; }

    public int? idEnterprice { get; set; }

    public int? idService { get; set; }

    public virtual tbl_client? idClientNavigation { get; set; }

    public virtual tbl_enterprice? idEnterpriceNavigation { get; set; }

    public virtual tbl_service? idServiceNavigation { get; set; }
}
