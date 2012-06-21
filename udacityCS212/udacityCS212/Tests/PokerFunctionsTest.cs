using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace udacityCS212.Tests
{
    class PokerFunctionsTest
    {

        [Test]
        public void SingleStraightFlushHandWinsGame()
        {
            var expected = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Queen),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var fourOfAKindHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                    });
            var fullHouseHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                    });
            var flushHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Six),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var straightHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Queen),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ace),
                    });
            var threeOfAKindHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                    }); 
            var twoPairHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var onePairHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var highCardHand= new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Two),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var asserted =
                new List<PokerEntities.Hand>
                    {
                        expected,
                        fourOfAKindHand,
                        fullHouseHand,
                        flushHand,
                        straightHand,
                        threeOfAKindHand,
                        twoPairHand,
                        onePairHand,
                        highCardHand
                    }.CalculatePoker();
            Assert.AreEqual(1, asserted.Count);
            Assert.AreEqual(expected, asserted.First());
        }

        [Test]
        public void TwoStraightsShareGameWin()
        {
            var straightHandOne = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Queen),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ace),
                    });
            var straightHandTwo = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Queen),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ace),
                    });
            var threeOfAKindHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                    });
            var twoPairHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var onePairHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var highCardHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Two),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var asserted =
                new List<PokerEntities.Hand>
                    {
                        //flipped around the natural order to demonstrate no dependency on input list order
                        threeOfAKindHand,
                        twoPairHand,
                        straightHandOne,
                        onePairHand,
                        straightHandTwo,
                        highCardHand
                    }.CalculatePoker();
            Assert.AreEqual(2, asserted.Count);
            Assert.Contains(straightHandOne, asserted);
            Assert.Contains(straightHandTwo, asserted);
        }

        [Test]
        public void FiftyTwoCardsInDeck()
        {
            Assert.AreEqual(52, PokerFunctions.GenerateDeck().Count);
        }


        [Test]
        public void TestDeal()
        {
            var twoPairHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var onePairHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var highCardHand = new PokerEntities.Hand(new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Two),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });


            //notice we don't shuffle the deck here, and the dealing is non-regular
            // i.e. we give one player all his cards, the we give next player all his, and so on..
            var theDeck = twoPairHand.Cards.Concat(onePairHand.Cards.Concat(highCardHand.Cards));

            var dealtCards = PokerFunctions.Deal(theDeck.ToList(), 3);

            Assert.AreEqual(twoPairHand, dealtCards[0]);
            Assert.AreEqual(onePairHand,dealtCards[1]);
            Assert.AreEqual(highCardHand, dealtCards[2]);
        }

        [Test]
        // tests that the binomial coefficient 45 2 equals 990
        public void FortyFiveCardsGenerateNineHundredNinetyPairs()
        {
            var myDeck = PokerFunctions.GenerateDeck();

            //could be any seven distinct cards
            var cardsToRemove = new List<PokerEntities.Card>
                                    {
                                 new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.King),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Jack),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Jack),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Seven),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Six),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Five),
                             };


            var reducedDeck = myDeck.RemoveFromDeck(cardsToRemove);
            var pairs = reducedDeck.GeneratePairs();
            const int expected = 990;
            Assert.AreEqual(expected, pairs.Count());
        }

        [Test]
        // tests that the binomial coefficient 52 2 equals 1326
        public void FiftyTwoCardsGenerateOneThousandThreeHundredTwentySixPairs()
        {
            var myDeck = PokerFunctions.GenerateDeck();
            var pairs = myDeck.GeneratePairs();
            const int expected = 1326;
            Assert.AreEqual(expected, pairs.Count());
        }


        [Test]
        // tests that the binomial coefficient  5 3 equals 10
        public void FlopOfFiveCardsGeneratesTenTriples()
        {
            var myFlop = new List<PokerEntities.Card>
                             {
                                 new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.King),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Jack),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Jack),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Seven),
                             };

            var myTriples = myFlop.GenerateTriples();
            const int expected = 10;
            Assert.AreEqual(expected,myTriples.Count());
        }


        [Test]
        public void FourOfAKindJacksIsHighest()
        {
            var thePair = new List<PokerEntities.Card>
                             {
                                 new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Jack),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Jack)
                             };

            var theFlop = new List<PokerEntities.Card>
                              {
                                 new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.King),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Jack),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Jack),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Seven),
                             };
            var expected = Tuple.Create(990, 0, 0);
            var theOutComes = PokerFunctions.HandOutcomes(theFlop, thePair);
            Assert.AreEqual(expected.Item1, theOutComes.Item1);
            Assert.AreEqual(expected.Item2, theOutComes.Item2);
            Assert.AreEqual(expected.Item3, theOutComes.Item3);
        }
    }
}
