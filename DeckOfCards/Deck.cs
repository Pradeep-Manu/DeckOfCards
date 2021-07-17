using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    public class Deck
    {
        protected Random Random
        {
            get
            {
                return new Random();
            }
        }
        public List<Card> cards;
        List<Card> dealedCards = new List<Card>();
        public List<string> suitList = new List<string>() { "Spades", "Hearts", "Clubs", "Diamonds" };
        public List<string> rankList = new List<string>() { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        
        public Deck()
        {
            cards = suitList.SelectMany(
                        suit => rankList,
                        (suit, rank) => new Card(rank, suit))
                    .ToList();
        }
        
        public void ShuffleCards()
        {
            cards = cards.OrderBy(a => Random.Next()).ToList();
        }

        public Card DealACard()
        {
            Card selectedCard = null;
            int cardCount = cards.Count;
            int cardIndex = Random.Next(cardCount);
            if (cardCount > 0)
            {
                selectedCard = cards[cardIndex];
                cards.Remove(selectedCard);
            }
            return selectedCard;
        }
    }
}
