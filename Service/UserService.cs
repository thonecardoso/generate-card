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

        public User Update(int id, User user)
        {
            VerifyIfExists(id);
            user.LastModifiedDate = DateTime.Now;
            return _userRepository.Update(user);
        }

        public User GetOne(int id)
        {
            var foundUser = _userRepository.Get(id);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }

            return foundUser;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Delete(int id)
        {
            VerifyIfExists(id);
            _userRepository.Delete(id);
        }

        private void VerifyIfExists(int id)
        {
            if (!_userRepository.VerifyIfExists(id))
            {
                throw new Exception("User not found");
            }
        }


        public List<User> GetAllFullUsers()
        {
           return _userRepository.getAllFullUsers();
        }
    }
}