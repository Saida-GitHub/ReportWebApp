using Microsoft.EntityFrameworkCore;

namespace ReportWebApp.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

    }
}
