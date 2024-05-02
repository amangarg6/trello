using Microsoft.EntityFrameworkCore;
using trello.Models;

namespace trello.Data
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        { }
        public  DbSet<Register>registers { get; set; }
        public  DbSet<Board>boards { get; set; }
        public  DbSet<List>lists { get; set; }
        public  DbSet<Card>cards { get; set; }
        public DbSet<Open> opens { get; set; }
        public DbSet<NewDescription> newDescriptions { get; set; }
        


    }
}
