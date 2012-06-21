using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace udacityCS212.Tests
{
    class AllConsecutiveTests
    {

        //remove when done, tests implementation not behaviour
        [Test]
        public void AllConsecutivesOrderedConsecutiveList()
        {
            Assert.AreEqual(true, (new List<int>() { 2, 3, 4, 5, 6 }).AllConsecutives());
        }

        //remove when done, tests implementation not behaviour
        [Test]
        public void AllConsecutivesUnOrderedConsecutiveList()
        {
            Assert.AreEqual(true, (new List<int>() { 3, 7, 4, 5, 6 }).AllConsecutives());
        }

        //remove when done, tests implementation not behaviour
        [Test]
        public void AllConsecutivesNonConsecutiveList()
        {
            Assert.AreEqual(false, (new List<int>() { 3, 8, 4, 5, 6 }).AllConsecutives());
        }

    }
}
