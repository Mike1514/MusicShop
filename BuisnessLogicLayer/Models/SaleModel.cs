using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BuisnessLogicLayer.Models
{
    public class SaleModel
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
}

