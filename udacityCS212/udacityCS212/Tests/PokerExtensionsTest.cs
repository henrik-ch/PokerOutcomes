using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace udacityCS212.Tests
{
    class PokerExtensionsTest
    {
        [Test]
        public void StraightFlush()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Queen),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Eight),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                    });
            var expected = new ReturnTypes.StraightFlushReturn(true, PokerEntities.CardRank.Queen);
            Assert.AreEqual(expected, testHand.Cards.StraightFlush());
        }

        [Test]
        public void NoStraightFlush()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Eight),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                    });
            var expected = new ReturnTypes.StraightFlushReturn(false, null);
            Assert.AreEqual(expected, testHand.Cards.StraightFlush());
        }

        [Test]
        public void FourOfAKind()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                    });
            var expected = new ReturnTypes.FourOfAKindReturn(true, PokerEntities.CardRank.Ten, PokerEntities.CardRank.Ace);
            Assert.AreEqual(expected, testHand.Cards.FourOfAKind());
        }

        [Test]
        public void NotFourOfAKind()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.FourOfAKindReturn(false, null, null);
            Assert.AreEqual(expected, testHand.Cards.FourOfAKind());
        }



        [Test]
        public void FullHouse()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                    });
            var expected = new ReturnTypes.FullHouseReturn(true, PokerEntities.CardRank.Ten, PokerEntities.CardRank.Nine);
            Assert.AreEqual(expected, testHand.Cards.FullHouse());
        }

        [Test]
        public void NoFullHouse()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.FullHouseReturn(false, null, null);
            Assert.AreEqual(expected, testHand.Cards.FullHouse());
        }



        [Test]
        public void Flush()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Six),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.FlushReturn(true, new List<PokerEntities.CardRank>
                                                                          {
                                                                              PokerEntities.CardRank.Ace,
                                                                              PokerEntities.CardRank.King,
                                                                              PokerEntities.CardRank.Jack,
                                                                              PokerEntities.CardRank.Ten,
                                                                              PokerEntities.CardRank.Six,
                                                                          });
            Assert.AreEqual(expected, testHand.Cards.Flush());
        }

        [Test]
        public void NoFlush()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Six),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.FlushReturn(false, null);
            Assert.AreEqual(expected, testHand.Cards.Flush());
        }

        [Test]
        public void StraightFlushIsNoFlush()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Queen),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.FlushReturn(false, null);
            Assert.AreEqual(expected, testHand.Cards.Flush());
        }

        [Test]
        public void Straight()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Queen),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.StraightReturn(true, PokerEntities.CardRank.Ace);
            Assert.AreEqual(expected, testHand.Cards.Straight());
        }

        [Test]
        public void NoStraight()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.StraightReturn(false, null);
            Assert.AreEqual(expected, testHand.Cards.Straight());
        }

        [Test]
        public void AceStraight()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Two),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Four),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Three),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Five),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.StraightReturn(true, PokerEntities.CardRank.Five);
            Assert.AreEqual(expected, testHand.Cards.Straight());
        }

        [Test]
        public void TwoAceNoStraight()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Two),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Four),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Three),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ace),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.StraightReturn(false, null);
            Assert.AreEqual(expected, testHand.Cards.Straight());
        }

        [Test]
        public void StraightFlushIsNoStraight()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Six),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Four),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Three),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Five),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Two),
                    });
            var expected = new ReturnTypes.StraightReturn(false, null);
            Assert.AreEqual(expected, testHand.Cards.Straight());
        }

        [Test]
        public void ThreeOfAKind()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.King),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                    });
            var expected = new ReturnTypes.ThreeOfAKindReturn(true, PokerEntities.CardRank.Ten, PokerEntities.CardRank.Ace, PokerEntities.CardRank.King);
            Assert.AreEqual(expected, testHand.Cards.ThreeOfAKind());
        }

        [Test]
        public void NotThreeOfAKind()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Eight),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                    });
            var expected = new ReturnTypes.ThreeOfAKindReturn(false, null, null, null);
            Assert.AreEqual(expected, testHand.Cards.ThreeOfAKind());
        }

        [Test]
        public void FourOfAKindIsNotThreeOfAKind()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                    });
            var expected = new ReturnTypes.ThreeOfAKindReturn(false, null, null, null);
            Assert.AreEqual(expected, testHand.Cards.ThreeOfAKind());
        }

        [Test]
        public void FullHouseIsNotThreeOfAKind()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                    });
            var expected = new ReturnTypes.ThreeOfAKindReturn(false, null, null, null);
            Assert.AreEqual(expected, testHand.Cards.ThreeOfAKind());
        }


        [Test]
        public void TwoPair()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var expected = new ReturnTypes.TwoPairReturn(true, PokerEntities.CardRank.Ten, PokerEntities.CardRank.Nine, PokerEntities.CardRank.Eight);
            Assert.AreEqual(expected, testHand.Cards.TwoPair());
        }

        [Test]
        public void NotTwoPair()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var expected = new ReturnTypes.TwoPairReturn(false, null, null, null);
            Assert.AreEqual(expected, testHand.Cards.TwoPair());
        }

        [Test]
        public void FullHouseIsNotTwoPair()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Nine),
                    });
            var expected = new ReturnTypes.TwoPairReturn(false, null, null, null);
            Assert.AreEqual(expected, testHand.Cards.TwoPair());
        }

        [Test]
        public void FourOfAKindIsNotTwoPair()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Nine),
                    });
            var expected = new ReturnTypes.TwoPairReturn(false, null, null, null);
            Assert.AreEqual(expected, testHand.Cards.TwoPair());
        }

        [Test]
        public void Pair()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var expected = new ReturnTypes.OnePairReturn(true, PokerEntities.CardRank.Ten, PokerEntities.CardRank.Nine, PokerEntities.CardRank.Eight, PokerEntities.CardRank.Seven);
            Assert.AreEqual(expected, testHand.Cards.OnePair());
        }

        [Test]
        public void NotPair()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Six),
                    });
            var expected = new ReturnTypes.OnePairReturn(false, null, null, null, null);
            Assert.AreEqual(expected, testHand.Cards.OnePair());
        }

        [Test]
        public void ThreeOfAKindIsNotPair()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Six),
                    });
            var expected = new ReturnTypes.OnePairReturn(false, null, null, null, null);
            Assert.AreEqual(expected, testHand.Cards.OnePair());
        }

        [Test]
        public void TwoPairIsNotPair()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Jack),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Six),
                    });
            var expected = new ReturnTypes.OnePairReturn(false, null, null, null, null);
            Assert.AreEqual(expected, testHand.Cards.OnePair());
        }


        [Test]
        public void HighCard()
        {
            var testHand = new PokerEntities.Hand(
                new List<PokerEntities.Card>
                    {
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Seven),
                        new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Nine),
                        new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Ten),
                        new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Two),
                        new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                    });
            var expected = new ReturnTypes.HighCardReturn(true, new List<PokerEntities.CardRank> { PokerEntities.CardRank.Ten, PokerEntities.CardRank.Nine, PokerEntities.CardRank.Eight, PokerEntities.CardRank.Seven, PokerEntities.CardRank.Two });
            Assert.AreEqual(expected, testHand.Cards.HighCard());
        }


    }
}
