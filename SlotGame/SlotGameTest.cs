using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Reels_same_order_return_100()
        {
            var slotMaching = new SlotMachine();

            string[] reel = { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };

            var reelItems = new List<string[]> { reel, reel, reel };
            int[] spinIndexes = { 0, 0, 0 };

            var slotScore = slotMaching.GetSlotScore(reelItems, spinIndexes);
            Assert.AreEqual(100, slotScore);
        }
    }

    public class SlotMachine
    {
        //        private int reel1 =
        public int GetSlotScore(List<string[]> reelItems, int[] spinIndexes)
        {
            for (var reelNum = 0; reelNum < spinIndexes.Length; reelNum++)
            {
                var spinItemIndex = spinIndexes[reelNum];
                if (reelItems[reelNum][spinItemIndex] != "Wild")
                {
                    return 0;
                }
            }

            return 100;
        }
    }
}