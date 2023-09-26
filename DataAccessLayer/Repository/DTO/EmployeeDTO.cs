using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.DTO
{
    public class EmployeeDTO
    {
        public long Id { get; set; }

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public long StoreId { get; set; }

        public string Position { get; set; } = null!;
    }
}
