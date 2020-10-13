using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static System.SystemExtensions;

namespace UnitTests
{
    [TestClass]
    public class ReverseWordsTests
    {
        private char[] Expected { get; set; }
        private char[] Actual { get; set; }

        [TestMethod]
        public void NullInput()
        {
            ReverseWords(Actual);
            Actual.ShouldBe(Expected);
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

            ReverseWords(Actual);
            Actual.ShouldBe(Expected);
        }

        [TestMethod]
        public void OneWordTest()
        {
            Expected = "Lorem".ToCharArray();
            Actual = "Lorem".ToCharArray();

            ReverseWords(Actual);
            Actual.ShouldBe(Expected);
        }

        [TestMethod]
        public void TwoWordsTest()
        {
            Expected = "Lorem ipsum".ToCharArray();
            Actual = "ipsum Lorem".ToCharArray();

            ReverseWords(Actual);
            Actual.ShouldBe(Expected);
        }

        [TestMethod]
        public void ThreeWordsTest()
        {
            Expected = "Lorem ipsum dolor".ToCharArray();
            Actual = "dolor ipsum Lorem".ToCharArray();

            ReverseWords(Actual);
            Actual.ShouldBe(Expected);
        }

        [TestMethod]
        public void MultipleWordsSameLength()
        {
            Expected = "in eu at ac".ToCharArray();
            Actual = "ac at eu in".ToCharArray();

            ReverseWords(Actual);
            Actual.ShouldBe(Expected);
        }

        [TestMethod]
        public void MultipleWordsDifferentLengths()
        {
            Expected = "A lorem amit".ToCharArray();
            Actual = "amit lorem A".ToCharArray();

            ReverseWords(Actual);
            Actual.ShouldBe(Expected);
        }
    }
}
