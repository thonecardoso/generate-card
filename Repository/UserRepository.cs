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
                .ToList();

            foreach (var user in users)
            {
                user.Cards = _context
                    .Set<Card>()
                    .Where(card => card.UserEmail == user.Email)
                    .ToList();
            }

            return users;
        }
        
        public bool VerifyIfExists(string email)
        {
            return _context
                .Set<User>()
                .Any(entity => entity.Email == email);
        }
        
        public User DeleteByEmail(string email)
        {
            User entity = _context.Set<User>()
                .Find(email);

            if (entity == null)
            {
                return null;
            }

            _context.Set<User>().Remove(entity);
            _context.SaveChanges();

            return entity;
        }
        
        public User getUserByEmail(string email)
        {
            var foundUser = _context
                .Set<User>()
                .Find(email);

            
            foundUser.Cards = _context
                    .Set<Card>()
                    .Where(card => card.UserEmail == email)
                    .ToList()
                    .OrderBy(x => x.CreatedDate)
                    .ToList();

            return foundUser;
        }
    }
}
//entity => entity.Email.Equals(email)