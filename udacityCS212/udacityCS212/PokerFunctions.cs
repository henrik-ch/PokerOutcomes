using System;
using System.Collections.Generic;
using System.Linq;

namespace udacityCS212
{
    static class PokerFunctions
    {
        /// <summary>
        /// returns the winning hands out of the hands submitted
        /// </summary>
        /// <param name="hands">hands for consideration</param>
        /// <returns></returns>
        public static List<PokerEntities.Hand> CalculatePoker(this IEnumerable<PokerEntities.Hand> hands)
        {
            var myHandsAndValue = hands.Select(myhand =>  Tuple.Create(myhand, myhand.CalculateHandValue()));

            var sortedHands = myHandsAndValue.OrderByDescending(aTuple => aTuple.Item2);
            var firstItem = sortedHands.First();
            return sortedHands.TakeWhile(curTuple => curTuple.Item2.CompareTo(firstItem.Item2) == 0).Select(myTuple => myTuple.Item1).ToList();
        }

        public static List<PokerEntities.Card> GenerateDeck()
        {
            var retList = new List<PokerEntities.Card>();

            foreach (var suit in Enum.GetValues(typeof(PokerEntities.CardSuit)))
            {
                retList.AddRange(
                    Enum.GetValues(typeof (PokerEntities.CardRank)).Cast<object>().Select(
                        rank => new PokerEntities.Card((PokerEntities.CardSuit) suit, (PokerEntities.CardRank) rank)));
            }
            return retList;
        }

        public static List<PokerEntities.Hand> Deal(List<PokerEntities.Card> deck, int numPlayers, int numCards = 5)
        {
            var retList = new List<PokerEntities.Hand>();
            var currentCardIndex = 0;

            for (int i = 0; i < numPlayers; i++)
            {
                retList.Add(new PokerEntities.Hand(deck.GetRange(currentCardIndex, numCards)));
                currentCardIndex = currentCardIndex + numCards;
            }
            return retList;
        }

        public static IEnumerable<List<PokerEntities.Card>> GeneratePairs(this List<PokerEntities.Card> remainingCards)
        {
            var allPairs =
                from cardOne in remainingCards
                from cardTwo in remainingCards
                where !cardOne.Equals(cardTwo)
                where cardOne.CompareTo(cardTwo) == 1
                select new List<PokerEntities.Card> {cardOne, cardTwo};

            return allPairs;
        }

        public static IEnumerable<List<PokerEntities.Card>> GenerateTriples(this List<PokerEntities.Card> theFlop)
        {
            var allFlopTriples = from cardOne in theFlop
                                 from cardTwo in theFlop
                                 from cardThree in theFlop
                                 where !cardOne.Equals(cardTwo)
                                 where !cardTwo.Equals(cardThree)
                                 where !cardThree.Equals(cardOne)
                                 where cardOne.CompareTo(cardTwo) == 1
                                 where cardTwo.CompareTo(cardThree) == 1
                                 select new List<PokerEntities.Card> { cardOne, cardTwo, cardThree };
            return allFlopTriples;
        }

        public static List<PokerEntities.Card> RemoveFromDeck(this IEnumerable<PokerEntities.Card> deck, IEnumerable<PokerEntities.Card> cardsToRemove)
        {
            var reducedDeck = new List<PokerEntities.Card>(deck);
            reducedDeck.RemoveAll(cardsToRemove.Contains);
            return reducedDeck;
        }

        public static Tuple<int, int, int> HandOutcomes(List<PokerEntities.Card> theFlop, List<PokerEntities.Card> pairOnHand)
        {
            var allFlopTriples = theFlop.GenerateTriples().ToList();
            var allTakenCards = pairOnHand.Concat(theFlop);

            var allMyHands = allFlopTriples.Select(triple => new PokerEntities.Hand(triple.Concat(pairOnHand)));
            var myBestHand = allMyHands.CalculatePoker().First();

            var deck = GenerateDeck();

            var reducedDeck = deck.RemoveFromDeck(allTakenCards);
            var pairs = reducedDeck.GeneratePairs();

            var allPairsAndTheirBestHands =
                pairs.Select(
                    thisPair =>
                    Tuple.Create(thisPair,
                                 (allFlopTriples.Select(triple => new PokerEntities.Hand(triple.Concat(thisPair)))).
                                     CalculatePoker().First())).ToList();

            var comparedHands =
                allPairsAndTheirBestHands.Select(
                    thisTuple =>
                    Tuple.Create(thisTuple.Item1,
                                 (new List<PokerEntities.Hand> { thisTuple.Item2, myBestHand }).CalculatePoker())).ToList();

            var winningHands = comparedHands.Where(thisTuple => thisTuple.Item2.Contains(myBestHand) && thisTuple.Item2.Count == 1);

            var drawingHands = comparedHands.Where(thisTuple => thisTuple.Item2.Contains(myBestHand) && thisTuple.Item2.Count > 1);

            var losingHands = comparedHands.Where(thisTuple => !thisTuple.Item2.Contains(myBestHand));
            return Tuple.Create(winningHands.Count(), drawingHands.Count(), losingHands.Count());
        }
    }
}