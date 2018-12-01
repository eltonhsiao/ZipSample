using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ZipSample.test
{
    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void Union_integers()
        {
            var first = new List<int> { 1, 3, 5 };
            var second = new List<int> { 5, 3, 7, 9 };

            var expected = new List<int> { 1, 3, 5, 7, 9 };

            var actual = MyUnion(first, second);
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<int> MyUnion(IEnumerable<int> first, IEnumerable<int> second)
        {
            throw new NotImplementedException();
        }
    }
}