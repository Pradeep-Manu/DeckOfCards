using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DeckOfCards.Step_definitions
{
    [Binding]
    class DeckOfPlayingCardsSteps
    {
        private List<string> suitList = new List<string>() { "Spades", "Hearts", "Clubs", "Diamonds" };
        private List<string> faceList = new List<string>() { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        Deck newDeck; 
        List<string> suits;
        List<Card> cards;

        [Given(@"a deck of cards")]
        public void GivenADeckOfCards()
        {
            newDeck = new Deck();
        }

        [When(@"I count each card")]
        public void WhenICountEachCard()
        {
            cards = newDeck.cards;
        }

        [Then(@"I have a total of (.*) cards")]
        public void ThenIHaveATotalOfCards(int numberOfcards)
        {
            Assert.AreEqual(numberOfcards, cards.Count(), "Total Number of Cards is " + numberOfcards);
        }

        [When(@"I check for suits")]
        public void WhenICheckForSuits()
        {
            suits = newDeck.suitList;
        }

        [Then(@"I see hearts, clubs, spades, and diamonds")]
        public void ThenISeeHeartsClubsSpadesAndDiamonds()
        {
            var firstNotSecond = suits.Except(suitList);
            var secondNotFirst = suitList.Except(suits);
            Assert.IsTrue(suits.Count() == 4 && firstNotSecond.Count() == 0 && secondNotFirst.Count() == 0, "Deck has " + suits.Count() + " Suits.");
        }

        [When(@"I count all the cards in a single suit")]
        public void WhenICountAllTheCardsInASingleSuit()
        {
            cards = newDeck.cards;
        }

        [Then(@"I have 13 cards: ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King")]
        public void ThenIHaveCardsAceJackQueenKing()
        {
            var suitGroup = cards.GroupBy(x => x.Suit);

            Assert.AreEqual(suitGroup.Where(x=>x.Count() == 13).Count(),4, "Suit Doesn't have 13 Cards");
        }
        [When(@"I have a card with (.*)")]
        public void WhenIHaveACardWith(string SelectedCard)
        {
            cards = newDeck.cards;
        }

        [Then(@"the card is worth (.*)")]
        public void ThenTheCardIsWorth(string SelectedcardPoints, Table table)
        {
            var details = table.CreateSet<CarsAndPoints>();
            int points = 0;
            int.TryParse(SelectedcardPoints, out points);
            foreach (var row in details)
            {
                foreach (Card card in cards.Where(x=>x.points == points))
                {
                    if (row.Rank == card.Rank)
                    {
                        Assert.AreEqual(row.Points,card.points);
                    }
                }
            }
        }




        [Then(@"the face cards are ordered Jack, Queen, King")]
        public void ThenTheFaceCardsAreOrderedJackQueenKing()
        {

            cards = newDeck.cards;
            var orderedCards = (from a in cards
                              orderby a.Suit,a.sortOrder
                              select a).ToList();
            Assert.AreEqual(orderedCards[49].Rank, "Jack");
            Assert.AreEqual(orderedCards[50].Rank, "Queen");
            Assert.AreEqual(orderedCards[51].Rank, "King");

        }


    }
}
