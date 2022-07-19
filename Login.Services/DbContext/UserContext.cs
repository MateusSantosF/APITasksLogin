using Login.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Login.Services.Context
{
    public class UserContext: DbContext
    {

        public DbSet<User> Users { get; set; }


        public UserContext(DbContextOptions options) : base(options)
        {
          
        }


    }
}
