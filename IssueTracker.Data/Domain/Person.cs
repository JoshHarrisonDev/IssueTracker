using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data.Domain
{
    public class Person
    {
        public int ID { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string? Role { get; set; } 

        public string Email { get; set; } = default!;

        public string UserName { get; set; } = default!;

        public int? ProjectID { get; set; }
        public virtual Project? Project { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
