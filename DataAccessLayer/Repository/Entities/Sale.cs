using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace DataAccessLayer;

public partial class Sale
{
    public long Id { get; set; }

    public string TransactionDate { get; set; } = null!;

    public long Quantity { get; set; }

    public long StoreId { get; set; }

    public long EmployeeId { get; set; }

    public string? Note { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
