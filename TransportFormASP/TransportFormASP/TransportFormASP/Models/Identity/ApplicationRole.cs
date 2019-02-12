using Microsoft.AspNet.Identity.EntityFramework;

namespace TransportFormASP.Models.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }

        public string Description { get; set; }
    }
}