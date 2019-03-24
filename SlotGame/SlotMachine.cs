using System.Collections.Generic;
using System.Linq;

namespace SlotGameTest.cs
{
    public class SlotMachine
    {
        public int GetSlotScore(List<ReelItem[]> reelItems, int[] spinIndexes)
        {
            var slotReelItems = GetSlotResultItems(reelItems, spinIndexes);
            var slotScore = GetPrizeScore(slotReelItems);

            return slotScore;
        }

        private static List<ReelItem> GetSlotResultItems(List<ReelItem[]> reelItems, int[] spinIndexes)
        {
            var getSlotResultItems = new List<ReelItem>();
            for (var reelNum = 0; reelNum < spinIndexes.Length; reelNum++)
            {
                var spinItemIndex = spinIndexes[reelNum];
                var reelItem = reelItems[reelNum][spinItemIndex];
                getSlotResultItems.Add(reelItem);
            }

            return getSlotResultItems;
        }

        private static int GetPrizeScore(List<ReelItem> slotReelItems)
        {
            const int itemRepeatTimes = 3;
            var prizePool = new Dictionary<List<ReelItem>, int>(new ListComparer<ReelItem>())
            {
                { Enumerable.Repeat(ReelItem.Wild, itemRepeatTimes).ToList(), 100 },
                { Enumerable.Repeat(ReelItem.Star, itemRepeatTimes).ToList(), 90 },
                { Enumerable.Repeat(ReelItem.Bell, itemRepeatTimes).ToList(), 80 },
                { Enumerable.Repeat(ReelItem.Shell, itemRepeatTimes).ToList(), 70 },
                { Enumerable.Repeat(ReelItem.Seven, itemRepeatTimes).ToList(), 60 },
                { Enumerable.Repeat(ReelItem.Cherry, itemRepeatTimes).ToList(), 50 },
                { Enumerable.Repeat(ReelItem.Bar, itemRepeatTimes).ToList(), 40 },
                { Enumerable.Repeat(ReelItem.King, itemRepeatTimes).ToList(), 30 },
                { Enumerable.Repeat(ReelItem.Queen, itemRepeatTimes).ToList(), 20 },
                { Enumerable.Repeat(ReelItem.Jack, itemRepeatTimes).ToList(), 10 },

                {new List<ReelItem>(){ReelItem.Star, ReelItem.Star, ReelItem.Wild},  18},
                {new List<ReelItem>(){ReelItem.Bell, ReelItem.Bell, ReelItem.Wild},  16},
                {new List<ReelItem>(){ReelItem.Shell, ReelItem.Shell, ReelItem.Wild},  14},
                {new List<ReelItem>(){ReelItem.Seven, ReelItem.Seven, ReelItem.Wild},  12},
                {new List<ReelItem>(){ReelItem.Cherry, ReelItem.Cherry, ReelItem.Wild},  10},
                {new List<ReelItem>(){ReelItem.Bar, ReelItem.Bar, ReelItem.Wild},  8},
                {new List<ReelItem>(){ReelItem.King, ReelItem.King, ReelItem.Wild},  6},
                {new List<ReelItem>(){ReelItem.Queen, ReelItem.Queen, ReelItem.Wild},  4},
            };

            return prizePool[slotReelItems];
        }

        // reference: https://stackoverflow.com/questions/10020541/c-sharp-list-as-dictionary-key
        private class ListComparer<T> : IEqualityComparer<List<T>>
        {
            public bool Equals(List<T> x, List<T> y)
            {
                return x.OrderBy(t => t).SequenceEqual(y.OrderBy(t => t));
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