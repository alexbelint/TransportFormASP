using Microsoft.AspNet.Identity.EntityFramework;

namespace TransportFormASP.Models.Identity
{
    public class User: IdentityUser
    {
        public string FullName { get; set; }

        public User()
        {

        }
    }
}