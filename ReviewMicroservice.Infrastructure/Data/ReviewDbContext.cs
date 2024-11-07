using Microsoft.EntityFrameworkCore;
using ReviewMicroservice.ApplicaitonCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.Infrastructure.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options) : base(options) { }

        public DbSet<Customer_Review> Customer_Review { get; set; }
    }
}
