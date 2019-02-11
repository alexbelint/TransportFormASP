using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TransportFormASP.Models.Identity
{
    public class UserContext: IdentityDbContext<User>
    {
        public UserContext(): base ("IdentityDb") { }
        public static UserContext Create()
        {
            return new UserContext();
        }
    }
}