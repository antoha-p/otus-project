using Microsoft.EntityFrameworkCore;
using Domain.Entities.DebtLoadService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework.DebtLoadService
{
    public class DebtLoadDBContext : DbContext
    {
        public DebtLoadDBContext(DbContextOptions<DebtLoadDBContext>options) : base(options) 
        {        
        }

        public DbSet<DebtLoadUser> DebtLoadUsers { get; set; }

    }


}
