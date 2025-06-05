using Microsoft.EntityFrameworkCore;
using OBAWebAPI.Framework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBAWebAPI.Framework.Repository.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<ExampleModel> ExampleTable  { get; set; }
    }
}
