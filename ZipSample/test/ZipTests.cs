﻿using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void pair_3_girls_and_5_boys()
        {
            var girls = Repository.Get3Girls();
            var keys = Repository.Get5Keys();

            var girlAndBoyPairs = MyZip(girls, keys, (girl, key) => Tuple.Create(girl.Name, key.OwnerBoy.Name)).ToList();
            var expected = new List<Tuple<string, string>>
            {
                Tuple.Create("Jean", "Joey"),
                Tuple.Create("Mary", "Frank"),
                Tuple.Create("Karen", "Bob"),
            };

            expected.ToExpectedObject().ShouldEqual(girlAndBoyPairs);
        }

        private IEnumerable<TResult> MyZip<TResult>(IEnumerable<Girl> girls, IEnumerable<Key> keys, Func<Girl, Key, TResult> selector)
        {
            var girlEnumerator = girls.GetEnumerator();
            var keyEnumerator = keys.GetEnumerator();
            while (girlEnumerator.MoveNext() && keyEnumerator.MoveNext())
            {
                var girl = girlEnumerator.Current;
                var key = keyEnumerator.Current;
                yield return selector(girl, key);
            }
        }
    }
}