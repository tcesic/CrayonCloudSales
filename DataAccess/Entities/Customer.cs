using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Account>? Accounts { get; set; }
    }
}
