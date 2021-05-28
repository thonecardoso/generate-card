using System;
using System.Text;
using generate_card.Entity;
using generate_card.Repository;

namespace generate_card.Service
{
    
    public class CardService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICardRepository _cardRepository;
        private readonly Random _random = new Random();

        public CardService(IUserRepository userRepository, ICardRepository cardRepository)
        {
            _userRepository = userRepository;
            _cardRepository = cardRepository;
        }

        public User CreatedCard(string email)
        {
            var user = _userRepository.findByEmail(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            //var number = "654321";
            var size = 16;
            var builder = new StringBuilder(size);
            char offset = '0';
            const int lettersOffset = 10;
            
            for (var i = 0; i < size; i++)  
            {  
                var @char = (char)_random.Next(offset, offset + lettersOffset);  
                builder.Append(@char);  
            }

            var card = new Card();
            card.Number = builder.ToString();
            card.Validate = DateTime.Now.AddYears(5);
            card.User = user;
            card.SecurityCode = _random.Next(100, 999);
            card.UserId = user.Id;
            
            //user.Cards.Add(card);

            _cardRepository.Add(card);

            return _userRepository.Get(user.Id);

        }
        
    }
}