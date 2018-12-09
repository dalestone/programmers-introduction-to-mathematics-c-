using SecretSharing.Extensions;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecretSharing.Tests
{
    public class StripEndTests
    {
        [Fact]
        public void Test_StripEnd_Empty()
        {
            var expected = new int[] { };
            var actual = new List<int> { }.StripEnd(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_StripEnd_Single()
        {
            var expected = new int[] { 1, 2, 3 };
            var actual = new List<int> { 1, 2, 3, 1 }.StripEnd(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_StripEnd_Many()
        {
            var expected = new int[] { 1, 2, 3 };
            var actual = new List<int> { 1, 2, 3, 1, 1, 1, 1 }.StripEnd(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_StripEnd_String()
        {
            var expected = "123";
            var actual = "123111".StripEnd('1');

            Assert.Equal(expected, actual);
        }
    }
}