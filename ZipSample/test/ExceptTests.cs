﻿using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ExceptTests
    {
        [TestMethod]
        public void Except_integers()
        {
            var first = new List<int> { 1, 3, 5, 5, 4, 4 };
            var second = new List<int> { 5, 3, 7, 9 };

            var expected = new List<int> { 1, 4 };

            var actual = MyExcept(first, second).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<int> MyExcept(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var hashSet = new HashSet<int>(second);
            while (firstEnumerator.MoveNext())
            {
                if (hashSet.Add(firstEnumerator.Current))
                    yield return firstEnumerator.Current;
            }
        }
    }
}