using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.DTO
{
    public class StoreDTO
    {
        public long Id { get; set; }

        public string StoreName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string WorkingHours { get; set; } = null!;

    }
}
