using CRUDTrial.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDTrial.DAO
{
    public class UserDBContext:DbContext
    {
        public UserDBContext() 
        { }

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        { }
        public DbSet<UserData> UserDatas { get; set; }

    }
}
