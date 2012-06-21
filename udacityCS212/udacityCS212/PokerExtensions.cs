using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace udacityCS212
{
    internal static class PokerExtensions
    {
        public static ReturnTypes.StraightFlushReturn StraightFlush(this List<PokerEntities.Card> cards)
        {
            var consecutive = cards.ConsecutiveRank();

            if (consecutive.IsConsecutive && cards.SameSuit())
            {
                return new ReturnTypes.StraightFlushReturn(true, consecutive.HighCardValue);
            }
            return new ReturnTypes.StraightFlushReturn(false, null);
        }

        public static ReturnTypes.FourOfAKindReturn FourOfAKind(this List<PokerEntities.Card> cards)
        {
            var groupedCards = cards.GroupBy(card => card.Rank).ToList();
            var fourOfAKindList =
                groupedCards.Where(g => g.Count() == 4).ToList();
            var isFourOfaKind = fourOfAKindList.Count == 1;

            if (isFourOfaKind)
            {
                var singleCard =
                    groupedCards.First(g => g.Count() == 1);
                return new ReturnTypes.FourOfAKindReturn(true, fourOfAKindList.First().Key,
                                                         singleCard.Key);
            }
            return new ReturnTypes.FourOfAKindReturn(false, null, null);
        }

        public static ReturnTypes.FullHouseReturn FullHouse(this List<PokerEntities.Card> cards)
        {
            var threeOfAKindList =
                cards.GroupBy(myCard => myCard.Rank).Where(g => g.Count() == 3).ToList();

            var twoOfAKindList =
                cards.GroupBy(myCard => myCard.Rank).Where(g => g.Count() == 2).ToList();

            var isFullHouse = threeOfAKindList.Count == 1 && twoOfAKindList.Count == 1;

            if (isFullHouse)
            {
                return new ReturnTypes.FullHouseReturn(true, threeOfAKindList.First().Key,
                                                       twoOfAKindList.First().Key);
            }

            return new ReturnTypes.FullHouseReturn(false, null, null);
        }

        public static ReturnTypes.FlushReturn Flush(this List<PokerEntities.Card> cards)
        {

            if (cards.SameSuit() && !cards.ConsecutiveRank().IsConsecutive)
            {
                return new ReturnTypes.FlushReturn(true, cards.Select(myCard => myCard.Rank).ToList());
            }

            return new ReturnTypes.FlushReturn(false, null);
        }

        public static ReturnTypes.StraightReturn Straight(this List<PokerEntities.Card> cards)
        {
            var consecutive = cards.ConsecutiveRank();

            if (consecutive.IsConsecutive && !cards.SameSuit())
            {
                return new ReturnTypes.StraightReturn(true, consecutive.HighCardValue);
            }
            return new ReturnTypes.StraightReturn(false, null);
        }

        public static ReturnTypes.ThreeOfAKindReturn ThreeOfAKind(this List<PokerEntities.Card> cards)
        {
            var threeOfAKindList =
                cards.GroupBy(myCard => myCard.Rank).Where(g => g.Count() == 3).ToList();
            var oneOfAKindList =
                cards.GroupBy(myCard => myCard.Rank).Where(g => g.Count() == 1).ToList();
            var oneOfAKindNumList = oneOfAKindList.Select(g => (int) g.Key).ToList();

            // check also that it is not a full house or a four of a kind (to make order of checks irrelevant)
            var isThreeOfAKind = threeOfAKindList.Count == 1 && oneOfAKindList.Count == 2;

            if (isThreeOfAKind)
            {
                return new ReturnTypes.ThreeOfAKindReturn(true, threeOfAKindList.First().Key,
                                                          (PokerEntities.CardRank) oneOfAKindNumList.Max(),
                                                          (PokerEntities.CardRank) oneOfAKindNumList.Min());
            }

            return new ReturnTypes.ThreeOfAKindReturn(false, null, null, null);
        }

        public static ReturnTypes.TwoPairReturn TwoPair(this List<PokerEntities.Card> cards)
        {
            var twoOfAKindList =
                cards.GroupBy(myCard => myCard.Rank).Where(g => g.Count() == 2).ToList();
            var twoOfAKindNumList = twoOfAKindList.Select(g => (int) g.Key).ToList();
            var oneOfAKindList =
                cards.GroupBy(myCard => myCard.Rank).Where(g => g.Count() == 1).ToList();

            var isTwoPair = twoOfAKindList.Count == 2;

            if (isTwoPair)
            {
                return new ReturnTypes.TwoPairReturn(true, (PokerEntities.CardRank) twoOfAKindNumList.Max(),
                                                     (PokerEntities.CardRank) twoOfAKindNumList.Min(),
                                                     oneOfAKindList.First().Key);
            }
            return new ReturnTypes.TwoPairReturn(false, null, null, null);
        }

        public static ReturnTypes.OnePairReturn OnePair(this List<PokerEntities.Card> cards)
        {
            var twoOfAKindList =
                cards.GroupBy(myCard => myCard.Rank).Where(g => g.Count() == 2).ToList();
            var oneOfAKindList =
                cards.GroupBy(myCard => myCard.Rank).Where(g => g.Count() == 1).ToList();
            var oneOfAKindNumList = oneOfAKindList.Select(g => (int) g.Key).ToList();

            var isPair = twoOfAKindList.Count == 1;

            if (isPair)
            {
                return new ReturnTypes.OnePairReturn(true, twoOfAKindList.First().Key,
                                                     (PokerEntities.CardRank) oneOfAKindNumList.Max(),
                                                     (PokerEntities.CardRank)
                                                     oneOfAKindNumList.OrderByDescending(i => i).Skip(1).First(),
                                                     (PokerEntities.CardRank) oneOfAKindNumList.Min());
            }

            return new ReturnTypes.OnePairReturn(false, null, null, null, null);
        }

        public static ReturnTypes.HighCardReturn HighCard(this List<PokerEntities.Card> cards)
        {
            var oneOfAKindList =
                cards.GroupBy(myCard => myCard.Rank).Where(g => g.Count() == 1).ToList();

            // no false positives on Flush or Straight
            var isHighCard = oneOfAKindList.Count == 5 && !cards.SameSuit() && !cards.ConsecutiveRank().IsConsecutive;

            if (isHighCard)
            {
                return new ReturnTypes.HighCardReturn(true, cards.Select(myCard => myCard.Rank).ToList());
            }

            return new ReturnTypes.HighCardReturn(false, null);
        }


        public static List<PokerEntities.Card> Shuffle(this List<PokerEntities.Card> inDeck)
        {
            var retDeck = new List<PokerEntities.Card>(inDeck);

            using (var rnd = new RNGCryptoServiceProvider())
            {
                //Buffer storage
                var data = new byte[4];

                //iterate for each card
                for (int i = 0; i < inDeck.Count ; i++)
                {
                    //Fill buffer
                    rnd.GetBytes(data);

                    //Convert to Int32
                    int swapIndex = Math.Abs(BitConverter.ToInt32(data, 0))%inDeck.Count;
                    //Console.WriteLine("Current Swap Index: {0}", swapIndex);
                    var cardValue = retDeck[swapIndex];
                    retDeck[swapIndex] = retDeck[i];
                    retDeck[i] = cardValue;
                }

            }
            return retDeck;
        }
    }
}