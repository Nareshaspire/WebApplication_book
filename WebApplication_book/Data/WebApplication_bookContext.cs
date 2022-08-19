using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication_book.Models;

namespace WebApplication_book.Data
{
    public class WebApplication_bookContext : DbContext
    {
        public WebApplication_bookContext (DbContextOptions<WebApplication_bookContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication_book.Models.BookShow> BookShow { get; set; } = default!;
    }
}
