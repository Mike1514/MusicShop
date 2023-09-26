using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace DataAccessLayer;

public partial class Store
{
    public long Id { get; set; }

    public string StoreName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string WorkingHours { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
