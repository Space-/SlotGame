using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SlotGameTest.cs
{
    public class SlotGameTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Reels_same_order_three_Wild_return_100()
        {
            var slotMachine = new SlotMachine();

            var reel = GetReelItems();

            var reelItems = new List<ReelItem[]> { reel, reel, reel };
            int[] spinIndexes = { 0, 0, 0 };

            var slotScore = slotMachine.GetSlotScore(reelItems, spinIndexes, ReelItem.Wild);
            Assert.AreEqual(100, slotScore);
        }

        [Test]
        public void Reels_same_order_three_Star_return_90()
        {
            var slotMachine = new SlotMachine();

            var reel = GetReelItems();

            var reelItems = new List<ReelItem[]> { reel, reel, reel };
            int[] spinIndexes = { 1, 1, 1 };

            var slotScore = slotMachine.GetSlotScore(reelItems, spinIndexes, ReelItem.Star);
            Assert.AreEqual(90, slotScore);
        }

        private static ReelItem[] GetReelItems()
        {
            return Enum.GetValues(typeof(ReelItem)).Cast<ReelItem>().ToArray();
        }
    }
}