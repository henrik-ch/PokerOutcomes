using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace udacityCS212
{
    class Program
    {
        static void Main(string[] args)
        {

            var myPair = new List<PokerEntities.Card>
                             {
                                 new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Ace),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.King)
                             };

            var theFlop = new List<PokerEntities.Card>
                              {
                                 new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.King),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Spades, PokerEntities.CardRank.Jack),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Diamonds, PokerEntities.CardRank.Jack),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Hearts, PokerEntities.CardRank.Eight),
                                 new PokerEntities.Card(PokerEntities.CardSuit.Clubs, PokerEntities.CardRank.Seven),
                             };

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var myOutComes = PokerFunctions.HandOutcomes(theFlop, myPair);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            Console.WriteLine("Winning number: {0}", myOutComes.Item1);
            Console.WriteLine("Drawing number: {0}", myOutComes.Item2);
            Console.WriteLine("Losing number: {0}", myOutComes.Item3);

            Console.ReadLine();
        }
    }
}
