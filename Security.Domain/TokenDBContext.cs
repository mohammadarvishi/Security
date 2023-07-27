using Microsoft.EntityFrameworkCore;
using Security.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain
{
    public class TokenDBContext:DbContext
    {
        public TokenDBContext(DbContextOptions<TokenDBContext> options) : base(options)
        {
        }
        public DbSet<TokenDB> Token { get; set; }
    }
}
