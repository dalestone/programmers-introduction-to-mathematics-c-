using SecretSharing.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SecretSharing.Tests
{
    public class ZipLongestTests
    {
        [Fact]
        public void Test_ZipLongest_Empty()
        {
            var expected = new List<int> { };
            var actual = new List<int> { }.ZipLongest(new List<int> { }, 
                (first, second) => first + second);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_ZipLongest_Add()
        {
            var expected = new List<int> { 0, 0, 0 };
            var actual = new List<int> { 1, 2, 3 }.ZipLongest(new List<int> { 1, 2, 3 }, 
                (first, second) => first - second);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Test_ZipLongest_Sub()
        {
            var expected = new List<int> { 1, 2, 3 };
            var actual = new List<int> { 2, 4, 6 }.Zip(new List<int> { 1, 2, 3 },
                (first, second) => first - second);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_ZipLongest_ListCountDiff_Add()
        {
            var expected = new List<int> { 2, 4, 6, 7 };
            var actual = new List<int> { 1, 2, 3, 7 }.ZipLongest(new List<int> { 1, 2, 3 },
                (first, second) => first + second);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_ZipLongest_ListCountDiff_Sub()
        {
            var expected = new List<int> { 0, 0, 0, 7 };
            var actual = new List<int> { 1, 2, 3, 7 }.ZipLongest(new List<int> { 1, 2, 3 },
                (first, second) => first - second);

            Assert.Equal(expected, actual);
        }

    }
}
