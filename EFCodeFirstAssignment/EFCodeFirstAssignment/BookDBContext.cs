using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstAssignment
{
    public class BookDBContext: DbContext
    {
        public BookDBContext() : base("name=efcfAssignment")
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
    }
}
