using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace BazaTest.Data
{
   

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }

}
