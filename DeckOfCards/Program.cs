using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Console.WriteLine("Deal Random Cards");
            deck.ShuffleCards();
            for (int i = 0; i < 53; i++)
            {
                var selectedCard = deck.DealACard();
                if (selectedCard != null)
                    Console.WriteLine(selectedCard.Suit + " " + selectedCard.Rank + " " + selectedCard.points);
                else
                    Console.WriteLine("No more card to deal");
            }
            Console.ReadLine();
        }
    }
    

    
}
