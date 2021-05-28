using System;
using System.Collections.Generic;
using generate_card.Entity;
using generate_card.Repository;

namespace generate_card.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(User user)
        {
            var addedUser = _userRepository.Add(user);
            return addedUser;
        }

        public User GetOne(string email)
        {
            var foundUser = _userRepository.getUserByEmail(email);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }

            return foundUser;
        }

        public void Delete(string email)
        {
            VerifyIfExists(email);
            _userRepository.DeleteByEmail(email);
        }

        public List<User> GetAllFullUsers()
        {
            return _userRepository.getAllFullUsers();
        }

        private void VerifyIfExists(string email)
        {
            if (!_userRepository.VerifyIfExists(email))
            {
                throw new Exception("User not found");
            }
        }
    }
}