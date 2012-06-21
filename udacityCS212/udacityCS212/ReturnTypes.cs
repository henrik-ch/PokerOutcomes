using System;
using System.Collections.Generic;
using System.Linq;

namespace udacityCS212
{
    public static class ReturnTypes
    {
        public class ConsecutiveRankReturn : IEquatable<ConsecutiveRankReturn>
        {
            public bool IsConsecutive { get; private set; }
            public PokerEntities.CardRank? HighCardValue { get; private set; }

            public ConsecutiveRankReturn(bool isConsecutive, PokerEntities.CardRank? highCardValue)
            {
                IsConsecutive = isConsecutive;
                HighCardValue = highCardValue;
            }

            public bool Equals(ConsecutiveRankReturn other)
            {
                return (IsConsecutive == other.IsConsecutive && HighCardValue == other.HighCardValue);
            }
        }


        public class StraightReturn : IEquatable<StraightReturn>, IComparable<StraightReturn>
        {
            public bool IsStraight { get; private set; }
            public PokerEntities.CardRank? HighCardValue { get; private set; } 
        
            public StraightReturn(bool isStraight, PokerEntities.CardRank? highCardValue)
            {
                IsStraight = isStraight;
                HighCardValue = highCardValue;
            }

            public bool Equals(StraightReturn other)
            {
                return (IsStraight == other.IsStraight && HighCardValue == other.HighCardValue);
            }

            public int CompareTo(StraightReturn other)
            {
                if (HighCardValue == null)
                    throw new Exception("Invalid state of return value");
                if(other.HighCardValue == null)
                    throw new Exception("Invalid state of return value");

                if ((int) HighCardValue > (int) other.HighCardValue)
                    //this greater
                    return 1;
                if ((int)HighCardValue < (int)other.HighCardValue)
                    //other greater
                    return -1;
                return 0;
            }
        }

        public class StraightFlushReturn : IEquatable<StraightFlushReturn>, IComparable<StraightFlushReturn>
        {
            public bool IsStraightFlush { get; private set; }
            public PokerEntities.CardRank? HighCardValue { get; private set; }

            public StraightFlushReturn(bool isStraightFlush, PokerEntities.CardRank? highCardValue)
            {
                IsStraightFlush = isStraightFlush;
                HighCardValue = highCardValue;
            }

            public bool Equals(StraightFlushReturn other)
            {
                return (IsStraightFlush == other.IsStraightFlush && HighCardValue == other.HighCardValue);
            }

            public int CompareTo(StraightFlushReturn other)
            {
                if (HighCardValue == null)
                    throw new Exception("Invalid state of return value");
                if (other.HighCardValue == null)
                    throw new Exception("Invalid state of return value");

                if ((int)HighCardValue > (int)other.HighCardValue)
                    //this greater
                    return 1;
                if ((int)HighCardValue < (int)other.HighCardValue)
                    //other greater
                    return -1;
                return 0;
            }
        }


        public class FourOfAKindReturn : IEquatable<FourOfAKindReturn>, IComparable<FourOfAKindReturn>
        {
            public bool IsFourOfAKind { get; private set; }
            public PokerEntities.CardRank? FourOfAKindRank { get; private set; }
            public PokerEntities.CardRank? SingleCardRank { get; private set; }

            public FourOfAKindReturn(bool isFourOfAKind, PokerEntities.CardRank? fourOfAKindRank, PokerEntities.CardRank? singleCardRank)
            {
                IsFourOfAKind = isFourOfAKind;
                FourOfAKindRank = fourOfAKindRank;
                SingleCardRank = singleCardRank;
            }

            public bool Equals(FourOfAKindReturn other)
            {
                return (IsFourOfAKind == other.IsFourOfAKind && FourOfAKindRank == other.FourOfAKindRank && SingleCardRank == other.SingleCardRank);
            }

            public int CompareTo(FourOfAKindReturn other)
            {
                if (FourOfAKindRank == null || SingleCardRank == null)
                    throw new Exception("Invalid state of return value");
                if (other.FourOfAKindRank == null || other.SingleCardRank == null)
                    throw new Exception("Invalid state of return value");

                if ((int) FourOfAKindRank > (int) other.FourOfAKindRank)
                    //this greater
                    return 1;
                if ((int)FourOfAKindRank < (int)other.FourOfAKindRank)
                    //other greater
                    return -1;
                if ((int)SingleCardRank > (int)other.SingleCardRank)
                    //this greater
                    return 1;
                if ((int) SingleCardRank < (int) other.SingleCardRank)
                    //other greater 
                    return -1;
                return 0;
            }
        }

        public class FullHouseReturn : IEquatable<FullHouseReturn>, IComparable<FullHouseReturn>
        {
            public bool IsFullHouse { get; private set; }
            public PokerEntities.CardRank? ThreeOfAKindRank { get; private set; }
            public PokerEntities.CardRank? TwoOfAKindRank { get; private set; }

            public FullHouseReturn(bool isFullHouse, PokerEntities.CardRank? threeOfAKindRank, PokerEntities.CardRank? twoOfAKindRank)
            {
                IsFullHouse = isFullHouse;
                ThreeOfAKindRank = threeOfAKindRank;
                TwoOfAKindRank = twoOfAKindRank;
            }

            public bool Equals(FullHouseReturn other)
            {
                return (IsFullHouse == other.IsFullHouse && ThreeOfAKindRank == other.ThreeOfAKindRank &&
                        TwoOfAKindRank == other.TwoOfAKindRank);
            }

            public int CompareTo(FullHouseReturn other)
            {
                if (ThreeOfAKindRank == null || TwoOfAKindRank == null)
                    throw new Exception("Invalid state of return value");

                if (other.ThreeOfAKindRank == null || other.TwoOfAKindRank == null)
                    throw new Exception("Invalid state of return value");

                if ((int) ThreeOfAKindRank > (int) other.ThreeOfAKindRank)
                    // this greater 
                    return 1;
                if ((int)ThreeOfAKindRank < (int)other.ThreeOfAKindRank)
                    //other greater
                    return -1;
                if ((int) TwoOfAKindRank > (int) other.TwoOfAKindRank)
                    //this greater 
                    return 1;
                if ((int) TwoOfAKindRank < (int) other.TwoOfAKindRank)
                    //other greater
                    return -1;
                return 0;
            }
        }

        public class FlushReturn : IEquatable<FlushReturn>, IComparable<FlushReturn>
        {
            public bool IsFlush { get; private set; }
            
            // cardranks list does need to be sorted, so that same hand dealt in different order is correctly handled by Equals method
            public List<PokerEntities.CardRank> CardRanks { get; private set; }
 
            public FlushReturn(bool isFlush, IEnumerable<PokerEntities.CardRank> cardRanks )
            {
                IsFlush = isFlush;
                if(cardRanks == null)
                {
                    CardRanks = null;
                }
                else
                {
                    var inList = new List<PokerEntities.CardRank>(cardRanks).OrderByDescending(myRank => myRank);
                    CardRanks = new List<PokerEntities.CardRank>(inList);                    
                }
            }

            public bool Equals(FlushReturn other)
            {
                if (CardRanks == null)
                    return IsFlush == other.IsFlush;
                return (IsFlush == other.IsFlush && CardRanks.SequenceEqual(other.CardRanks));
            }

            public int CompareTo(FlushReturn other)
            {
                if(CardRanks.Count != other.CardRanks.Count)
                    throw new Exception("invalid input");

                for (int i = 0; i <= 4; i++)
                {
                    if ((int) CardRanks[i] > (int) other.CardRanks[i])
                        //this flush greater than other
                        return 1;
                    if ((int) CardRanks[i] < (int) other.CardRanks[i])
                        //this flush lesser than other
                        return -1;
                }
                //both flushes equal.
                return 0;
            }

        }

        public class ThreeOfAKindReturn : IEquatable<ThreeOfAKindReturn>, IComparable<ThreeOfAKindReturn>
        {
            public bool IsThreeOfAKind { get; private set; }
            public PokerEntities.CardRank? ThreeOfAKindRank { get; private set; }
            public PokerEntities.CardRank? HigherSingleCardRank { get; private set; }
            public PokerEntities.CardRank? LowerSingleCardRank { get; private set; }

            public ThreeOfAKindReturn(bool isThreeOfAKind, PokerEntities.CardRank? threeOfAKindRank, PokerEntities.CardRank? higherSingleCardRank, PokerEntities.CardRank? lowerSingleCardRank)
            {
                IsThreeOfAKind = isThreeOfAKind;
                ThreeOfAKindRank = threeOfAKindRank;
                HigherSingleCardRank = higherSingleCardRank;
                LowerSingleCardRank = lowerSingleCardRank;
            }

            public bool Equals(ThreeOfAKindReturn other)
            {
                return (IsThreeOfAKind == other.IsThreeOfAKind && ThreeOfAKindRank == other.ThreeOfAKindRank && HigherSingleCardRank == other.HigherSingleCardRank && LowerSingleCardRank == other.LowerSingleCardRank);
            }

            public int CompareTo(ThreeOfAKindReturn other)
            {
                if(ThreeOfAKindRank == null || HigherSingleCardRank == null || LowerSingleCardRank == null)
                    throw new Exception("Invalid state of return value");
                if (other.ThreeOfAKindRank == null || other.HigherSingleCardRank == null || other.LowerSingleCardRank == null)
                    throw new Exception("Invalid state of return value");

                if (ThreeOfAKindRank > other.ThreeOfAKindRank)
                    //this greater
                    return 1;
                if (ThreeOfAKindRank < other.ThreeOfAKindRank)
                    //other greater
                    return -1;
                if (HigherSingleCardRank > other.HigherSingleCardRank)
                    //this greater
                    return 1;
                if (HigherSingleCardRank < other.HigherSingleCardRank)
                    //other greater
                    return -1;
                if (LowerSingleCardRank > other.LowerSingleCardRank)
                    //this greater
                    return 1;
                if (LowerSingleCardRank < other.LowerSingleCardRank)
                    //other greater
                    return -1;
                return 0;
            }
        }

        public class TwoPairReturn : IEquatable<TwoPairReturn>, IComparable<TwoPairReturn>
        {
            public bool IsTwoPair { get; private set; }
            public PokerEntities.CardRank? HighPairRank { get; private set; }
            public PokerEntities.CardRank? LowPairRank { get; private set; }
            public PokerEntities.CardRank? SingleCardRank { get; private set; }

            public TwoPairReturn(bool isTwoPair, PokerEntities.CardRank? highPairRank, PokerEntities.CardRank? lowPairRank, PokerEntities.CardRank? singleCardRank)
            {
                IsTwoPair = isTwoPair;
                HighPairRank = highPairRank;
                LowPairRank = lowPairRank;
                SingleCardRank = singleCardRank;
            }

            public bool Equals(TwoPairReturn other)
            {
                return (IsTwoPair == other.IsTwoPair && HighPairRank == other.HighPairRank && LowPairRank == other.LowPairRank && SingleCardRank == other.SingleCardRank);
            }

            public int CompareTo(TwoPairReturn other)
            {
                if (HighPairRank== null || LowPairRank == null || SingleCardRank == null)
                    throw new Exception("Invalid state of return value");
                if (other.HighPairRank == null || other.LowPairRank == null || other.SingleCardRank== null)
                    throw new Exception("Invalid state of return value");
                if (HighPairRank > other.HighPairRank)
                    //this greater
                    return 1;
                if (HighPairRank < other.HighPairRank)
                    //other greater
                    return -1;
                if (LowPairRank > other.LowPairRank)
                    //this greater
                    return 1;
                if (LowPairRank < other.LowPairRank)
                    //other greater
                    return -1;
                if (SingleCardRank > other.SingleCardRank)
                    //this greater
                    return 1;
                if (SingleCardRank < other.SingleCardRank)
                    //other greater
                    return -1;
                return 0;
            }
        }


        public class OnePairReturn : IEquatable<OnePairReturn>, IComparable<OnePairReturn>
        {
            public bool IsPair { get; private set; }
            public PokerEntities.CardRank? PairRank { get; private set; }
            public PokerEntities.CardRank? HighSingleCardRank { get; private set; }
            public PokerEntities.CardRank? MiddleSingleCardRank { get; private set; }
            public PokerEntities.CardRank? LowSingleCardRank { get; private set; }

            public OnePairReturn(bool isPair, PokerEntities.CardRank? pairRank, PokerEntities.CardRank? highSingleCardRank, PokerEntities.CardRank? middleSingleCardRank, PokerEntities.CardRank? lowSingleCardRank)
            {
                IsPair = isPair;
                PairRank = pairRank;
                HighSingleCardRank = highSingleCardRank;
                MiddleSingleCardRank = middleSingleCardRank;
                LowSingleCardRank = lowSingleCardRank;
            }

            public bool Equals(OnePairReturn other)
            {
                return (IsPair == other.IsPair && PairRank == other.PairRank &&
                        HighSingleCardRank == other.HighSingleCardRank &&
                        MiddleSingleCardRank == other.MiddleSingleCardRank &&
                        LowSingleCardRank == other.LowSingleCardRank);
            }

            public int CompareTo(OnePairReturn other)
            {
                if (PairRank == null || HighSingleCardRank == null || MiddleSingleCardRank == null || LowSingleCardRank == null)
                    throw new Exception("Invalid state of return value");
                if (other.PairRank == null || other.HighSingleCardRank == null || other.MiddleSingleCardRank == null || other.LowSingleCardRank == null)
                    throw new Exception("Invalid state of return value");
                if (PairRank > other.PairRank)
                    //this greater
                    return 1;
                if (PairRank < other.PairRank)
                    //other greater
                    return -1;
                if (HighSingleCardRank > other.HighSingleCardRank)
                    //this greater
                    return 1;
                if (HighSingleCardRank < other.HighSingleCardRank)
                    //other greater
                    return -1;
                if (MiddleSingleCardRank > other.MiddleSingleCardRank)
                    //this greater
                    return 1;
                if (MiddleSingleCardRank < other.MiddleSingleCardRank)
                    //other greater
                    return -1;
                if (LowSingleCardRank> other.LowSingleCardRank)
                    //this greater
                    return 1;
                if (LowSingleCardRank < other.LowSingleCardRank)
                    //other greater
                    return -1;
                return 0;
            }
        }

        public class HighCardReturn : IEquatable<HighCardReturn>, IComparable<HighCardReturn>
        {
            public bool IsHighCard { get; private set; }

            // cardranks list does need to be sorted, so that same hand dealt in different order is correctly handled by Equals method
            public List<PokerEntities.CardRank> CardRanks { get; private set; }

            public HighCardReturn(bool isHighCard, List<PokerEntities.CardRank> cardRanks)
            {
                IsHighCard = isHighCard;
                var inList = new List<PokerEntities.CardRank>(cardRanks).OrderByDescending(myRank => myRank);
                CardRanks = new List<PokerEntities.CardRank>(inList);
            }

            public bool Equals(HighCardReturn other)
            {
                return (IsHighCard == other.IsHighCard && CardRanks.SequenceEqual(other.CardRanks));
            }

            public int CompareTo(HighCardReturn other)
            {
                if (CardRanks.Count != other.CardRanks.Count)
                    throw new Exception("invalid input");

                for (int i = 0; i <= 4; i++)
                {
                    if ((int)CardRanks[i] > (int)other.CardRanks[i])
                        //this greater
                        return 1;
                    if ((int)CardRanks[i] < (int)other.CardRanks[i])
                        //other greater
                        return -1;
                }
                //both highcards equal.
                return 0;
            }
        }




    }
}