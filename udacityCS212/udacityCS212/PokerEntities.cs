using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace udacityCS212
{
    public static class PokerEntities
    {
        public enum CardRank
        {
            Ace = 14,
            King = 13,
            Queen = 12,
            Jack = 11,
            Ten = 10,
            Nine = 9,
            Eight = 8,
            Seven = 7,
            Six = 6,
            Five = 5,
            Four = 4,
            Three = 3,
            Two = 2,
        }

        public enum CardSuit
        {
            Clubs,
            Spades,
            Hearts,
            Diamonds,
        }

        public class Card : ICloneable, IEquatable<Card>, IComparable<Card>
        {
            public CardSuit Suit {get; private set;}
            public CardRank Rank { get; private set; }

            public Card(CardSuit inSuit, CardRank inRank)
            {
                Suit = inSuit;
                Rank = inRank;
            }

            public object Clone()
            {
                return new Card(Suit, Rank);
            }

            public bool Equals(Card other)
            {
                if (other != null)
                {
                    return (other.Rank == Rank && other.Suit == Suit);
                }
                return false;
            }

            // no cards may compare like -> i.e never return a zero.
            public int CompareTo(Card other)
            {
                var rankCompare = ((int) Rank).CompareTo(((int) other.Rank));
                return rankCompare == 0 ? ((int) Suit).CompareTo(((int) other.Suit)) : rankCompare;
            }

            public override string ToString()
            {
                return Suit.ToString() + " " + Rank.ToString();
            }
        }

        public class Hand : IEquatable<Hand>
        {
            public List<Card> Cards { get; private set; }

            public Hand(IEnumerable<Card> inCards )
            {
                var inHand = (List<Card>)inCards.ToList().Clone();
                Cards = inHand;
            }

            public bool Equals(Hand other)
            {
                if(other != null)
                {
                    return Cards.TrueForAll(item => other.Cards.Contains(item)) && (Cards.Count == other.Cards.Count);
                }
                return false;
            }

            public override string ToString()
            {
                var aggregateString = Cards.Aggregate(
                    new StringBuilder(), (myStringBuilder, myCard) => myStringBuilder.Append(";"  + myCard.ToString()),myStringBuilder => myStringBuilder.Remove(0,1).ToString());

                return aggregateString;
            }
            
            public IHandValue CalculateHandValue()
            {
                var sf = Cards.StraightFlush();
                if(sf.IsStraightFlush)
                {
                    return new StraightFlushHandValue(sf);
                }
                var fk = Cards.FourOfAKind();
                if (fk.IsFourOfAKind)
                {
                    return new FourOfAKindHandValue(fk);                    
                }
                var fh = Cards.FullHouse();
                if(fh.IsFullHouse)
                {
                    return new FullHouseHandValue(fh);
                }
                var f = Cards.Flush();
                if (f.IsFlush)
                {
                    return new FlushHandValue(f);
                }
                var s = Cards.Straight();
                if (s.IsStraight)
                {
                    return new StraightHandValue(s);
                }
                var tok = Cards.ThreeOfAKind();
                if (tok.IsThreeOfAKind)
                {
                    return new ThreeOfAKindHandValue(tok);
                }
                var tp = Cards.TwoPair();
                if (tp.IsTwoPair)
                {
                    return new TwoPairHandValue(tp);
                }
                var op = Cards.OnePair();
                if (op.IsPair)
                {
                    return new OnePairHandValue(op);
                }
                var hc = Cards.HighCard();
                return   new HighCardHandValue(hc);
            }
        }

        public interface IHandValue :IComparable<IHandValue>, IEquatable<IHandValue>
        {
        }

        public class StraightFlushHandValue : IHandValue
        {
            public ReturnTypes.StraightFlushReturn RetVal { get; private set; }

            public int CompareTo(IHandValue other)
            {
                if( other is StraightFlushHandValue)
                {
                    var typedOther = other as StraightFlushHandValue;
                    return RetVal.CompareTo(typedOther.RetVal);
                }

                // Straight flush is greater than all other hands.
                return 1;
            }

            public StraightFlushHandValue( ReturnTypes.StraightFlushReturn retVal)
            {
                if (!retVal.IsStraightFlush)
                {
                    throw new Exception("not a straight flush hand value");
                }
                RetVal = retVal;
            }

            public bool Equals(IHandValue other)
            {
                if( !(other is StraightFlushHandValue))
                {
                    return false;
                }
                var typedOther = other as StraightFlushHandValue;
                return RetVal.Equals(typedOther.RetVal);
            }
        }

        public class FourOfAKindHandValue : IHandValue
        {
            public ReturnTypes.FourOfAKindReturn RetVal { get; private set; }

            public int CompareTo(IHandValue other)
            {
                if (other is FourOfAKindHandValue)
                {
                    var typedOther = other as FourOfAKindHandValue;
                    return RetVal.CompareTo(typedOther.RetVal);
                }

                // Four of a kind is less than straight flush
                if (other is StraightFlushHandValue)
                {
                    return -1;
                }

                //four of a kind beats all other hands
                return 1;
            }

            public FourOfAKindHandValue(ReturnTypes.FourOfAKindReturn retVal)
            {
                if (!retVal.IsFourOfAKind)
                {
                    throw new Exception("not a four of a kind hand value");
                }
                RetVal = retVal;
            }

            public bool Equals(IHandValue other)
            {
                if (!(other is FourOfAKindHandValue))
                {
                    return false;
                }
                var typedOther = other as FourOfAKindHandValue;
                return RetVal.Equals(typedOther.RetVal);
            }
        }


        public class FullHouseHandValue : IHandValue
        {
            public ReturnTypes.FullHouseReturn RetVal { get; private set; }

            public int CompareTo(IHandValue other)
            {
                if (other is FullHouseHandValue)
                {
                    var typedOther = other as FullHouseHandValue;
                    return RetVal.CompareTo(typedOther.RetVal);
                }

                // full house is less than straight flush and four of a kind
                if (other is StraightFlushHandValue || other is FourOfAKindHandValue)
                {
                    return -1;
                }

                //full house beats all other hands
                return 1;
            }

            public FullHouseHandValue(ReturnTypes.FullHouseReturn retVal)
            {
                if (!retVal.IsFullHouse)
                {
                    throw new Exception("not a full house hand value");
                }
                RetVal = retVal;
            }

            public bool Equals(IHandValue other)
            {
                if (!(other is FullHouseHandValue))
                {
                    return false;
                }
                var typedOther = other as FullHouseHandValue;
                return RetVal.Equals(typedOther.RetVal);
            }
        }


        public class FlushHandValue :IHandValue
        {

            public ReturnTypes.FlushReturn RetVal { get; private set; }

            public int CompareTo(IHandValue other)
            {
                if (other is FlushHandValue)
                {
                    var typedOther = other as FlushHandValue;
                    return RetVal.CompareTo(typedOther.RetVal);
                }

                // flush is less than straight flush, four of a kind and full house
                if (other is StraightFlushHandValue || other is FourOfAKindHandValue || other is FullHouseHandValue)
                    return -1;

                //flush beats all other hands
                return 1;
            }

            public FlushHandValue(ReturnTypes.FlushReturn retval)
            {
                if(!retval.IsFlush)
                    throw new Exception("not a flush hand value.");
                RetVal = retval;
            }

            public bool Equals(IHandValue other)
            {
                if (!(other is FlushHandValue))
                    return false;
                var typedOther = other as FlushHandValue;
                return RetVal.Equals(typedOther.RetVal);

            }
        }

        public class StraightHandValue : IHandValue
        {
            public ReturnTypes.StraightReturn RetVal { get; private set; }


            public int CompareTo(IHandValue other)
            {
                if(other is StraightHandValue)
                {
                    var typedOther = other as StraightHandValue;
                    return RetVal.CompareTo(typedOther.RetVal);
                }

                //straight is less than straight flush, four of a kind, full house and flush
                if (other is StraightFlushHandValue || other is FourOfAKindHandValue || other is FullHouseHandValue ||
                    other is FlushHandValue)
                    return -1;

                //straight beats all other hands
                return 1;
            }

            public StraightHandValue(ReturnTypes.StraightReturn retval)
            {
                if (!retval.IsStraight)
                    throw new Exception("not a straight hand value.");
                RetVal = retval;
            }

            public bool Equals(IHandValue other)
            {
                if (!(other is StraightHandValue))
                    return false;
                var typedOther = other as StraightHandValue;
                return RetVal.Equals(typedOther.RetVal);
            }
        }

        public class ThreeOfAKindHandValue : IHandValue
        {

            public ReturnTypes.ThreeOfAKindReturn RetVal { get; private set; }

            public int CompareTo(IHandValue other)
            {
                if(other is ThreeOfAKindHandValue)
                {
                    var typedOther = other as ThreeOfAKindHandValue;
                    return RetVal.CompareTo(typedOther.RetVal);
                }

                //three of a kind is higher than two pair, pair and high card
                if (other is TwoPairHandValue || other is OnePairHandValue || other is HighCardHandValue)
                    return 1;

                //three of a kind loses against all other hands
                return -1;
            }

            public ThreeOfAKindHandValue(ReturnTypes.ThreeOfAKindReturn retval)
            {
                if(!retval.IsThreeOfAKind)
                    throw new Exception("not a three of a kind hand value.");
                RetVal = retval;
            }

            public bool Equals(IHandValue other)
            {
                if (!(other is ThreeOfAKindHandValue))
                    return false;
                var typedOther = other as ThreeOfAKindHandValue;
                return RetVal.Equals(typedOther.RetVal);
            }
        }

        public class TwoPairHandValue : IHandValue
        {
            public ReturnTypes.TwoPairReturn RetVal { get; private set; }

            public int CompareTo(IHandValue other)
            {
                if(other is TwoPairHandValue)
                {
                    var typedOther = other as TwoPairHandValue;
                    return RetVal.CompareTo(typedOther.RetVal);
                }

                //two pair is higher than one pair and high card
                if (other is OnePairHandValue || other is HighCardHandValue)
                    return 1;

                //two pair loses against all others
                return -1;
            }
            
            public TwoPairHandValue(ReturnTypes.TwoPairReturn retval)
            {
                if(!retval.IsTwoPair)
                    throw new Exception("not a two pair hand value");
                RetVal = retval;
            }

            public bool Equals(IHandValue other)
            {
                if (!(other is TwoPairHandValue))
                    return false;
                var typedOther = other as TwoPairHandValue;
                return RetVal.Equals(typedOther.RetVal);
            }
        }


        public class OnePairHandValue :IHandValue
        {
            public ReturnTypes.OnePairReturn RetVal { get; private set;}

            public int CompareTo(IHandValue other)
            {
                if(other is OnePairHandValue)
                {
                    var typedOther = other as OnePairHandValue;
                    return RetVal.CompareTo(typedOther.RetVal);
                }

                //one pair is higher than high card
                if (other is HighCardHandValue)
                    return 1;

                //one pair loses against all others.
                return -1;
            }

            public OnePairHandValue(ReturnTypes.OnePairReturn retval)
            {
                if(!retval.IsPair)
                    throw new Exception("not a pair hand value.");
                RetVal = retval;
            }

            public bool Equals(IHandValue other)
            {
                if (!(other is OnePairHandValue))
                    return false;
                var typedOther = other as OnePairHandValue;
                return RetVal.Equals(typedOther.RetVal);
            }
        }


        public class HighCardHandValue : IHandValue
        {
            public ReturnTypes.HighCardReturn RetVal { get; private set; }


            public int CompareTo(IHandValue other)
            {
                if(other is HighCardHandValue)
                {
                    var typedOther = other as HighCardHandValue;
                    return RetVal.CompareTo(typedOther.RetVal);
                }

                // high card loses against all other hands
                return -1;

            }

            public HighCardHandValue(ReturnTypes.HighCardReturn retval)
            {
                if(!retval.IsHighCard)
                    throw new Exception("not a high card value");
                RetVal = retval;
            }

            public bool Equals(IHandValue other)
            {
                if (!(other is HighCardHandValue))
                    return false;
                var typedOther = other as HighCardHandValue;
                return RetVal.Equals(typedOther.RetVal);
            }
        }

    }

}