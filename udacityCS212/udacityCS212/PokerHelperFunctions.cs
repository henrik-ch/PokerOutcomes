using System;
using System.Collections.Generic;
using System.Linq;

namespace udacityCS212
{
    /// <summary>
    /// these functions don't check according to poker game rules, they just conduct simple tests
    /// (and are used in the game rules checks)
    /// </summary>
    static class PokerHelperFunctions
    {
        public static bool SameSuit(this List<PokerEntities.Card> cards)
        {
            PokerEntities.Card first = null;
            foreach (var card in cards)
            {
                if (first == null)
                    first = card;
                else if (first.Suit != card.Suit)
                    return false;
            }
            return true;
        }

        public static ReturnTypes.ConsecutiveRankReturn ConsecutiveRank(this List<PokerEntities.Card> cards)
        {
            var intList = cards.Select(myCard => (int)myCard.Rank).ToList();
            
            if (intList.AllConsecutives())
            {
                return new ReturnTypes.ConsecutiveRankReturn(true, (PokerEntities.CardRank) intList.Max());
            }


            //flipped ace case
            bool hasOneAce = cards.FindAll(findCard => findCard.Rank == PokerEntities.CardRank.Ace).Count == 1;
            var noAceList = intList.FindAll(intVal => intVal != (int)PokerEntities.CardRank.Ace);
            var aceAsOneList = noAceList.Union(new List<int> { 1 }).ToList();
            if (hasOneAce && aceAsOneList.AllConsecutives() )
            {
                return new ReturnTypes.ConsecutiveRankReturn(true, (PokerEntities.CardRank)aceAsOneList.Max());
            }
            return new ReturnTypes.ConsecutiveRankReturn(false, null);
        }

        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }


    }

    static class Extensions
    {
        public static bool AllConsecutives(this IEnumerable<int> intValues)
        {
            if (intValues == null)
                return false;
            var orderedList = intValues.OrderBy(i => i).ToList();
            if (!orderedList.Any())
                return true;
            var expected = orderedList.Min();
            foreach (var intValue in orderedList)
            {
                if (intValue != expected)
                    return false;
                expected = expected + 1;
            }
            return true;
        }

    }
}