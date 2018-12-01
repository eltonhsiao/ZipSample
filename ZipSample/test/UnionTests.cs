using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

            var actual = MyUnion(first, second).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void Union_girls()
        {
            var first = new List<Girl>
            {
                new Girl{Name="lulu", Age = 18},
                new Girl{Name="lily", Age = 27}
            };
            var second = new List<Girl>
            {
                new Girl{Name="leo", Age = 25},
                new Girl{Name="lulu", Age = 18}
            };

            var expected = new List<Girl>
            {
                new Girl{Name="lulu", Age = 18},
                new Girl{Name="lily", Age = 27},
                new Girl{Name="leo", Age = 25}
            };

            var actual = MyUnion1(first, second, new GirlComparer()).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<int> MyUnion(IEnumerable<int> first, IEnumerable<int> second)
        {
            //return MyUnion1(first, second, EqualityComparer<int>.Default);
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            var result = new HashSet<int>();

            while (firstEnumerator.MoveNext())
            {
                if (result.Add(firstEnumerator.Current))
                {
                    yield return firstEnumerator.Current;
                }
            }

            while (secondEnumerator.MoveNext())
            {
                if (result.Add(secondEnumerator.Current))
                {
                    yield return secondEnumerator.Current;
                }
            }
        }

        private IEnumerable<Girl> MyUnion1(IEnumerable<Girl> first, IEnumerable<Girl> second, IEqualityComparer<Girl> girlComparer)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            var result = new HashSet<Girl>(girlComparer);

            while (firstEnumerator.MoveNext())
            {
                if (result.Add(firstEnumerator.Current))
                {
                    yield return firstEnumerator.Current;
                }
            }

            while (secondEnumerator.MoveNext())
            {
                if (result.Add(secondEnumerator.Current))
                {
                    yield return secondEnumerator.Current;
                }
            }
        }
    }

    internal class GirlComparer : IEqualityComparer<Girl>
    {
        public bool Equals(Girl x, Girl y)
        {
            return x.Name == y.Name && x.Age == y.Age;
        }

        public int GetHashCode(Girl obj)
        {
            return new { obj.Name, obj.Age }.GetHashCode();
            //return obj.Name.GetHashCode() + obj.Age.GetHashCode();
        }
    }
}