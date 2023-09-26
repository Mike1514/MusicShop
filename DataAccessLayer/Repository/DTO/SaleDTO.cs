using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.DTO
{
    public class SaleDTO
    {
        public long Id { get; set; }

        public string TransactionDate { get; set; } = null!;

        public long Quantity { get; set; }

        public long StoreId { get; set; }

        public long EmployeeId { get; set; }

        public string? Note { get; set; }
    }
}
