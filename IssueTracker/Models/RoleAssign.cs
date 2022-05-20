using IssueTracker.Data.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IssueTracker.Models
{
    public class RoleAssign
    {
        public IList<Person> RolelessPeople { get; set; }

        
        public IList<IdentityRole> Roles { get; set; }

        public string RoleName { get; set; }

        public int UserID { get; set; }
    }
}
