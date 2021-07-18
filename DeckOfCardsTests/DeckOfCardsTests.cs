using DeckOfCards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCardsTests
{
    [TestClass]
    public class DeckOfCardsTests
    {
        private Deck DeckOfCards;
        private List<Card> cards;

        public DeckOfCardsTests()
        {
            DeckOfCards = new Deck();
            cards = DeckOfCards.cards;
        }

        [TestMethod]
        public void CheckForValidDeck()
        {
            int RequireddSizeOfDeck = 52;
            Console.WriteLine("Total Card Count in a Deck: {0}", DeckOfCards.cards.Count);
            Assert.AreEqual(DeckOfCards.cards.Count, RequireddSizeOfDeck, "The Deck is Invalid Deck in Count of Cards.");
        }

        [TestMethod]
        public void CheckForValidNumberOfSuits()
        {
            var RequiredTotalNumberOfSuits = 4;
            Console.WriteLine("Deck's Distinct Suit Count: {0}", DeckOfCards.suitList.Count);
            Assert.AreEqual(DeckOfCards.suitList.Count, RequiredTotalNumberOfSuits, "The Deck is Invalid Deck in the Count of different Suits.");
        }

        [TestMethod]
        public void CheckForValidNumberOfCardsForEachRank()
        {
            var RequiredNumberOfCardsForEachRank = 4;
            var NumberOfCardsForEachRankThatAregreaterThenFour = cards.GroupBy(x => x.Rank).Where(x => x.Count() > RequiredNumberOfCardsForEachRank).Any();
            var NumberOfCardsForEachRankThatAregreaterLessFour = cards.GroupBy(x => x.Rank).Where(x => x.Count() < RequiredNumberOfCardsForEachRank).Any();
            Assert.IsTrue((NumberOfCardsForEachRankThatAregreaterThenFour == false && NumberOfCardsForEachRankThatAregreaterLessFour == false), "Invalid Deck. Deck Has more/less then Required Number of Rank Cards. (ie. Count of each Rank card in Deck is 4.");
        }

        [TestMethod]
        public void CheckForValidNumberOfCardsInSpadesSuit()
        {
            var RequiredNumberOfCardsInAGivenSuit = 13;
            var NumberOfCardsInSpadesSuit = DeckOfCards.cards.Where(x => x.Suit.Equals("Spades", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(NumberOfCardsInSpadesSuit.Count(), RequiredNumberOfCardsInAGivenSuit, "Given Number of Cards in Spades Suit is Invalid in a Deck.");
        }

        

    }
}
