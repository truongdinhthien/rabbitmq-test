using Microsoft.EntityFrameworkCore;
using Models;

namespace Receiver.Data
{
    public class MsgContext : DbContext
    {
        public MsgContext (DbContextOptions<MsgContext> options) : base(options)
        {

        }

        public DbSet<Message> Messages {get;set;}
    }
}