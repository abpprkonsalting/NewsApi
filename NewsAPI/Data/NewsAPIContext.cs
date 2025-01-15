using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Model;

namespace NewsAPI.Data
{
    public class NewsAPIContext : DbContext
    {
        public NewsAPIContext (DbContextOptions<NewsAPIContext> options)
            : base(options)
        {
        }
        public DbSet<NewsAPI.Model.News> News { get; set; } = default!;
    }
}
