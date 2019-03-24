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