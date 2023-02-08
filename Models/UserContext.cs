using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementSystem.Models
{
    //represents users DB
    public class UserContext:IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext>options):base(options)
        {

        }
    }
}
