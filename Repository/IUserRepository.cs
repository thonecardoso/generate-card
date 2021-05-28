using System.Collections.Generic;
using generate_card.Entity;

namespace generate_card.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> getAllFullUsers();

        User findByEmail(string email);
    }
}