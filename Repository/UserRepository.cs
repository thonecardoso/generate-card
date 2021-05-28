using System.Collections.Generic;
using System.Linq;
using generate_card.Context;
using generate_card.Entity;
using Microsoft.EntityFrameworkCore;

namespace generate_card.Repository
{
    public class UserRepository : RepositoryBase<User, GenerateCardContext>, IUserRepository
    {
        public UserRepository(GenerateCardContext context) : base(context)
        {
        }
        
        public User findByEmail(string email)
        {
            return _context
                .Set<User>()
                .FirstOrDefault(entity => entity.Email == email);
        }

        public List<User> getAllFullUsers()
        {
            var users = _context
                .Set<User>()
                // .Include(user => user.Cards)
                .ToList();

            foreach (var user in users)
            {
                user.Cards = _context
                    .Set<Card>()
                    .Where(card => card.UserId == user.Id)
                    .ToList();
            }

            return users;
        }
    }
}
//entity => entity.Email.Equals(email)