using DeckOfCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCardsTests
{
    [TestClass]
    public class CardsTests
    {
        private Deck DeckOfCards = new Deck();
        private List<Card> cards;
        private Card card;

        public CardsTests()
        {
            DeckOfCards = new Deck();
            cards = DeckOfCards.cards;
            card = new Card();
        }

        [TestMethod]
        public void CheckForValidCardCreation()
        {
            string rank = "2";
            string suit = "Spades";
            card = new Card(rank, suit);
            Card SpadesTwoCardFromDeck = cards.Where(x => x.Rank.Equals("2", StringComparison.OrdinalIgnoreCase) && x.Suit.Equals(suit, StringComparison.OrdinalIgnoreCase)).First();
            Console.WriteLine("Created Card Rank:{0}, Deck Card Rank: {1}",card.Rank,SpadesTwoCardFromDeck.Rank);
            Assert.IsTrue(SpadesTwoCardFromDeck.Rank == card.Rank, "Invalid Card. Cards Rank Doesn't Match.");
            Console.WriteLine("Created Card Suit:{0}, Deck Card Suit: {1}", card.Suit, SpadesTwoCardFromDeck.Suit);
            Assert.IsTrue(SpadesTwoCardFromDeck.Suit == card.Suit, "Invalid Card. Cards Suit Doesn't Match.");
            Console.WriteLine("Created Card points:{0}, Deck Card points: {1}", card.points, SpadesTwoCardFromDeck.points);
            Assert.IsTrue(SpadesTwoCardFromDeck.points == card.points, "Invalid Card. Cards points Doesn't Match.");
            Console.WriteLine("Created Card sortOrder:{0}, Deck Card sortOrder: {1}", card.sortOrder, SpadesTwoCardFromDeck.sortOrder);
            Assert.IsTrue(SpadesTwoCardFromDeck.sortOrder == card.sortOrder, "Invalid Card. sortOrder Doesn't Match.");
        }

        [TestMethod]
        public void CheckForValidNumberOfPointsForJackOfSpades()
        {
            var RequiredNumberOfPointsForJack = 10;
            var RequiredRank = "Jack";
            var RequiredSuit = "Spades";
            Console.WriteLine("Number of Points for Card: {0}", RequiredNumberOfPointsForJack);
            Console.WriteLine("Number of Rank for Card: {0}", RequiredRank);
            Console.WriteLine("Number of Suit for Card: {0}", RequiredSuit);
            var IndexForJackOfSpades = cards.FindIndex(x => x.Rank.Equals(RequiredRank) && x.Suit.Equals(RequiredSuit));
            var NumberOfPointsForJackOfSpades = DeckOfCards.cards[IndexForJackOfSpades].points;
            Assert.AreEqual(NumberOfPointsForJackOfSpades, RequiredNumberOfPointsForJack, "The Deck is Invalid Deck in the Count of different Suits.");
        }
        [TestMethod]
        public void CheckForValidNumberOfCardsForEachRank()
        {
            var RequiredNumberOfCardsForEachRank = 4;
            cards = DeckOfCards.cards;
            var IsThereAnyRankCardsCountGreaterThenFour = cards.GroupBy(x => x.Rank).Where(x => x.Count() > RequiredNumberOfCardsForEachRank).Any();
            var IsThereAnyRankCardsCountLesserThenFour = cards.GroupBy(x => x.Rank).Where(x => x.Count() < RequiredNumberOfCardsForEachRank).Any();
            Console.WriteLine("Required Number of Cards for each Rank in Deck: {0}", RequiredNumberOfCardsForEachRank);
            foreach(var rank in cards.GroupBy(x => x.Rank))
            {
                Console.WriteLine("Number Of Cards with Rank {0} :  {1}", rank.Key,rank.Count());
            }
            Console.WriteLine("There are any perticular Rank Card count in a Deck Greater then 4: {0}", IsThereAnyRankCardsCountGreaterThenFour);
            Console.WriteLine("There are any perticular Rank Card count in a Deck Lesser then 4: {0}", IsThereAnyRankCardsCountLesserThenFour);
            Assert.IsTrue((IsThereAnyRankCardsCountGreaterThenFour == false && IsThereAnyRankCardsCountLesserThenFour == false), "Invalid Deck. Deck Has more/less then Required Number of Rank Cards. (ie. Count of each Rank card in Deck is 4.");
        }
    }
}
