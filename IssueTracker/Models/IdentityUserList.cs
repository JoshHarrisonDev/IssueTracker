using Microsoft.AspNetCore.Identity;

namespace IssueTracker.Models
{
    public class IdentityUserList
    {
        public string? RoleName { get; set; }
        public IList<IdentityUser>? Users { get; set; }
    }
}
