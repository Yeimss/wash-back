using System;
using System.Collections.Generic;

namespace data.Models.Context;

public partial class tbl_enterprice
{
    public int id { get; set; }

    public string? enterprice { get; set; }

    public string? logoEmpresa { get; set; }

    public bool? sendEmail { get; set; }

    public bool? sendSMS { get; set; }

    public virtual ICollection<tbl_client> tbl_clients { get; set; } = new List<tbl_client>();

    public virtual ICollection<tbl_encargado> tbl_encargados { get; set; } = new List<tbl_encargado>();

    public virtual ICollection<tbl_service> tbl_services { get; set; } = new List<tbl_service>();

    public virtual ICollection<tbl_user> tbl_users { get; set; } = new List<tbl_user>();

    public virtual ICollection<tbl_washed> tbl_washeds { get; set; } = new List<tbl_washed>();
}
