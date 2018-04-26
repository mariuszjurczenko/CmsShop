using System.Data.Entity;

namespace CmsShop.Models.Data
{
    public class Db : DbContext
    {
        public DbSet<PageDTO> Pages { get; set; }

    }
}