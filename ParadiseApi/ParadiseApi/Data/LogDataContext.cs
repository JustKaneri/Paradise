using Microsoft.EntityFrameworkCore;
using ParadiseApi.Models;

namespace ParadiseApi.Data
{
    public class LogDataContext: DbContext
    {
        public LogDataContext(DbContextOptions<LogDataContext> options) : base(options) { }

        public DbSet<Logging> Logs => Set<Logging>();
    }
}
