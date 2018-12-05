using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZipSample.test
{
    [TestClass]
    public class BetPractice
    {
        [TestMethod]
        public void First()
        {
            Bet bet = new Bet()
            {
                Id = 123,
                Stake = 1.5M,
                CreatedDate = new DateTime(2018, 12, 01)
            };

            var betDto = new BetDto();
            var actual = betDto.BetDtoMapping(bet, p => new BetDto()
            {
                Amount = (int)Math.Round(p.Stake),
                BetId = p.Id,
                Date = p.CreatedDate.ToString("yyyyMMdd")
            });
            Assert.AreEqual(actual.BetId, 123);
            Assert.AreEqual(actual.Amount, 2);
            Assert.AreEqual(actual.Date, "20181201");
        }

        [TestMethod]
        public void Second()
        {
            Bet bet = new Bet()
            {
                Id = 123,
                Stake = 1.5M,
                CreatedDate = new DateTime(2018, 12, 01)
            };

            var betDto = new BetDto();
            var actual = betDto.BetDtoMap(bet, new BetMapper());
            Assert.AreEqual(actual.BetId, 123);
            Assert.AreEqual(actual.Amount, 1);
            Assert.AreEqual(actual.Date, "20181201");
        }

        [TestMethod]
        public void Third()
        {
            Bet bet = new Bet()
            {
                Id = 123,
                Stake = 1.5M,
                CreatedDate = new DateTime(2018, 12, 01),
                Status = "Win"
            };

            var betDto = new BetDto();
            var actual = betDto.BetDtoMap(bet);
            Assert.AreEqual(actual.Status, "Win");
        }
    }
}