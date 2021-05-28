using generate_card.Context;
using generate_card.Entity;

namespace generate_card.Repository
{
    public class CardRepository : RepositoryBase<Card, GenerateCardContext>, ICardRepository
    {
        public CardRepository(GenerateCardContext context) : base(context)
        {
        }
    }
}