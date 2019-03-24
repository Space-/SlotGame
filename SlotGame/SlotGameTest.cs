using System;
using System.Collections.Generic;
using System.Linq;
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

    public enum ReelItem
    {
        Wild,
        Star,
        Bell,
        Shell,
        Seven,
        Cherry,
        Bar,
        King,
        Queen,
        Jack
    }

    public class SlotMachine
    {
        public int GetSlotScore(List<ReelItem[]> reelItems, int[] spinIndexes, ReelItem prizeReelItem)
        {
            var slotReelItems = new List<ReelItem>();
            for (var reelNum = 0; reelNum < spinIndexes.Length; reelNum++)
            {
                var spinItemIndex = spinIndexes[reelNum];
                var reelItem = reelItems[reelNum][spinItemIndex];
                slotReelItems.Add(reelItem);
            }

            const int itemRepeatTimes = 3;
            var prizePool = new Dictionary<List<ReelItem>, int>(new ListComparer<ReelItem>())
            {
                { Enumerable.Repeat(ReelItem.Wild, itemRepeatTimes).ToList(), 100 },
                { Enumerable.Repeat(ReelItem.Star, itemRepeatTimes).ToList(), 90 }
            };

            var slotScore = 0;
            slotScore = prizePool[slotReelItems];

            return slotScore;
        }

        // reference: https://stackoverflow.com/questions/10020541/c-sharp-list-as-dictionary-key
        private class ListComparer<T> : IEqualityComparer<List<T>>
        {
            public bool Equals(List<T> x, List<T> y)
            {
                return x.SequenceEqual(y);
            }

            public int GetHashCode(List<T> obj)
            {
                int hashcode = 0;
                foreach (T t in obj)
                {
                    hashcode ^= t.GetHashCode();
                }
                return hashcode;
            }
        }
    }
}