using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Using Shouldly for better comparison semantics for things like char[]
using Shouldly;
using static System.SystemExtensions;

namespace UnitTests
{
    [TestClass]
    public class ReverseStringTests
    {
        private char[] Expected { get; set; }
        private char[] Actual { get; set; }

        [TestMethod]
        public void NullInput()
        {
            Reverse(Actual);
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void EmptyInput()
        {
            // This can be written three ways:
            //  new char[0]
            //  Array.Empty<char>()
            //  string.Empty.ToCharArray()

            Expected = Array.Empty<char>();
            Actual = Array.Empty<char>();

            Reverse(Actual);
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void SingleCharInput()
        {
            // Can also be written "A".ToCharArray()
            Expected = new[] {'A'};
            Actual = new[] {'A'};

            Reverse(Actual);
            Actual.ShouldBe(Expected);
        }

        [TestMethod]
        public void DoubleCharInput()
        {
            Expected = new[] { 'B', 'A' };
            // Can also be written "AB".ToCharArray()
            Actual = new[] { 'A', 'B' };

            Reverse(Actual);
            Actual.ShouldBe(Expected);
        }

        [TestMethod]
        public void TripleCharInput()
        {
            Expected = new[] { 'C', 'B', 'A' };
            // Can also be written "ABC".ToCharArray()
            Actual = new[] { 'A', 'B', 'C' };

            Reverse(Actual);
            Actual.ShouldBe(Expected);
        }
    }
}
