using System.Collections.Generic;
using generate_card.Entity;

namespace generate_card.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> getAllFullUsers();

        User findByEmail(string email);

        public bool VerifyIfExists(string email);

        public User DeleteByEmail(string email);

        public User getUserByEmail(string email);
    }
}