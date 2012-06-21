using System.Collections.Generic;
using NUnit.Framework;

namespace udacityCS212.Tests
{
    class FlushReturnTests
    {

        //flush return tests could be seen as testing of implementation rather than behaviour, consider removing when done

        [Test]
        public void FlushReturnNotEqual()
        {
            var flushReturnOne = new ReturnTypes.FlushReturn(true,
                                                                      new List<PokerEntities.CardRank>
                                                                          {
                                                                              PokerEntities.CardRank.Ten,
                                                                              PokerEntities.CardRank.Nine,
                                                                              PokerEntities.CardRank.Eight,
                                                                              PokerEntities.CardRank.Seven,
                                                                              PokerEntities.CardRank.Six
                                                                          });
            var flushReturnTwo = new ReturnTypes.FlushReturn(true,
                                                                      new List<PokerEntities.CardRank>
                                                                          {
                                                                              PokerEntities.CardRank.Ten,
                                                                              PokerEntities.CardRank.Nine,
                                                                              PokerEntities.CardRank.Eight,
                                                                              PokerEntities.CardRank.Seven,
                                                                              PokerEntities.CardRank.Five
                                                                          });
            Assert.AreNotEqual(flushReturnOne, flushReturnTwo);
        }




        //this could be seen as testing of implementation rather than behaviour, consider removing when done
        [Test]
        public void FlushReturnOrderedEqual()
        {
            var flushReturnOne = new ReturnTypes.FlushReturn(true,
                                                                      new List<PokerEntities.CardRank>
                                                                          {
                                                                              PokerEntities.CardRank.Ten,
                                                                              PokerEntities.CardRank.Nine,
                                                                              PokerEntities.CardRank.Eight,
                                                                              PokerEntities.CardRank.Seven,
                                                                              PokerEntities.CardRank.Six
                                                                          });
            var flushReturnTwo = new ReturnTypes.FlushReturn(true,
                                                                      new List<PokerEntities.CardRank>
                                                                          {
                                                                              PokerEntities.CardRank.Ten,
                                                                              PokerEntities.CardRank.Nine,
                                                                              PokerEntities.CardRank.Eight,
                                                                              PokerEntities.CardRank.Seven,
                                                                              PokerEntities.CardRank.Six
                                                                          });
            Assert.AreEqual(flushReturnOne, flushReturnTwo);
        }

        //this could be seen as testing of implementation rather than behaviour, consider removing when done
        [Test]
        public void FlushReturnUnOrderedEqual()
        {
            var flushReturnOne = new ReturnTypes.FlushReturn(true,
                                                                      new List<PokerEntities.CardRank>
                                                                          {
                                                                              PokerEntities.CardRank.Ten,
                                                                              PokerEntities.CardRank.Nine,
                                                                              PokerEntities.CardRank.Eight,
                                                                              PokerEntities.CardRank.Seven,
                                                                              PokerEntities.CardRank.Six
                                                                          });
            var flushReturnTwo = new ReturnTypes.FlushReturn(true,
                                                                      new List<PokerEntities.CardRank>
                                                                          {
                                                                              PokerEntities.CardRank.Six,
                                                                              PokerEntities.CardRank.Seven,
                                                                              PokerEntities.CardRank.Eight,
                                                                              PokerEntities.CardRank.Nine,
                                                                              PokerEntities.CardRank.Ten
                                                                          });
            Assert.AreEqual(flushReturnOne, flushReturnTwo);
        }



    }
}
