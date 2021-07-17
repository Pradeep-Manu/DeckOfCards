using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    public class Card
    {
        public string Suit { get; protected set; }
        public string Rank { get; protected set; }
        public int points
        {
            get {
                int value = 0;
                if (Rank.Equals("ace"))
                {
                    return 1;
                }
                else if(int.TryParse(Rank, out value))
                {
                    return value;
                }
                else
                {
                    return 10;
                }
            }
        }

        public int sortOrder
        {
            get
            {
                int num = 0;
                switch (Suit)
                {
                    case "ace":
                       return 1;
                    case "Jack":
                        return 11;
                    case "Queeen":
                        return 12;
                    case "King":
                        return 13;
                    default:
                        {
                            int.TryParse(Suit, out num);
                            return num;
                        }
                }
            }
        }
        public Card(string rank, string suit)
        {
            Suit = suit;
            Rank = rank;
        }

        public Card()
        {
        }
    }

    public class CarsAndPoints
    {
        public string Rank { get; set; }
        public int Points { get; set; }
    }
}
