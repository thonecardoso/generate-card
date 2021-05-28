using generate_card.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace generate_card.Context
{
    public class GenerateCardContext : DbContext
    {
        public GenerateCardContext(DbContextOptions<GenerateCardContext> options, ILogger<GenerateCardContext> logger) : base(options)
        {
            logger.LogInformation("Created new Context");
        }

        public virtual DbSet<Card> CardContext { get; set; }
        public virtual DbSet<User> UserContext { get; set; }
        
    }
}