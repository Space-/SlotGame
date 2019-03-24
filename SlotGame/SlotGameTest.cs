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

            GameResultShouldBe(100, reelItems, spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_Star_return_90()
        {
            var reel = GetReelItems();

            var reelItems = new List<ReelItem[]> { reel, reel, reel };
            int[] spinIndexes = { 1, 1, 1 };

            GameResultShouldBe(90, reelItems, spinIndexes);
        }

        private static void GameResultShouldBe(int expected, List<ReelItem[]> reelItems, int[] spinIndexes)
        {
            var slotMachine = new SlotMachine();
            var slotScore = slotMachine.GetSlotScore(reelItems, spinIndexes);
            Assert.AreEqual(expected, slotScore);
        }

        private static ReelItem[] GetReelItems()
        {
            return Enum.GetValues(typeof(ReelItem)).Cast<ReelItem>().ToArray();
        }
    }
}