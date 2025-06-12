using Microsoft.EntityFrameworkCore;
using OBAFramework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBAFramework.Repository.Infrastructure
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
