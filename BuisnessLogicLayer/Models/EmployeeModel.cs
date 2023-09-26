using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BuisnessLogicLayer.Models
{
    public class EmployeeModel
    {
        public long Id { get; set; }

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public long StoreId { get; set; }

        public string Position { get; set; } = null!;

        //public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

        //public virtual Store Store { get; set; } = null!;
    }
}
