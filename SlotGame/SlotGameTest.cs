using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SlotGameTest.cs
{
    public class SlotGameTest
    {
        private static List<ReelItem[]> _reelItems;
        private static int[] _spinIndexes;

        [SetUp]
        public void InitSlotMachineReels()
        {
            var reel = GetReelItems();
            _reelItems = new List<ReelItem[]> { reel, reel, reel };
        }

        [Test]
        public void Reels_same_order_three_Wild_return_100()
        {
            _spinIndexes = new[] { 0, 0, 0 };
            GameResultShouldBe(100);
        }

        [Test]
        public void Reels_same_order_three_Star_return_90()
        {
            _spinIndexes = new[] { 1, 1, 1 };
            GameResultShouldBe(90);
        }

        [Test]
        public void Reels_same_order_three_Bell_return_80()
        {
            _spinIndexes = new[] { 2, 2, 2 };
            GameResultShouldBe(80);
        }

        [Test]
        public void Reels_same_order_three_Shell_return_70()
        {
            _spinIndexes = new[] { 3, 3, 3 };
            GameResultShouldBe(70);
        }

        [Test]
        public void Reels_same_order_three_Seven_return_60()
        {
            _spinIndexes = new[] { 4, 4, 4 };
            GameResultShouldBe(60);
        }

        [Test]
        public void Reels_same_order_three_Cherry_return_50()
        {
            _spinIndexes = new[] { 5, 5, 5 };
            GameResultShouldBe(50);
        }

        [Test]
        public void Reels_same_order_three_Bar_return_40()
        {
            _spinIndexes = new[] { 6, 6, 6 };
            GameResultShouldBe(40);
        }

        [Test]
        public void Reels_same_order_three_King_return_30()
        {
            _spinIndexes = new[] { 7, 7, 7 };
            GameResultShouldBe(30);
        }

        [Test]
        public void Reels_same_order_three_Queen_return_20()
        {
            _spinIndexes = new[] { 8, 8, 8 };
            GameResultShouldBe(20);
        }

        [Test]
        public void Reels_same_order_three_Queen_return_10()
        {
            _spinIndexes = new[] { 9, 9, 9 };
            GameResultShouldBe(10);
        }

        private static void GameResultShouldBe(int expected)
        {
            var slotMachine = new SlotMachine();
            var slotScore = slotMachine.GetSlotScore(_reelItems, _spinIndexes);
            Assert.AreEqual(expected, slotScore);
        }

        private static ReelItem[] GetReelItems()
        {
            return Enum.GetValues(typeof(ReelItem)).Cast<ReelItem>().ToArray();
        }
    }
}