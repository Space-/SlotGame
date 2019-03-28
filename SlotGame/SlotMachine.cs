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
            return spinIndexes.Select((spinItemIndex, reelNum) => reelItems[reelNum][spinItemIndex]).ToList();
        }

        private static List<ReelItem> GetPrizeFilterReelItems(List<ReelItem> slotReelItems)
        {
            var itemGroupList = slotReelItems.GroupBy(v => v).Select(item => new { Item = item.Key, Cnt = item.Count() }).ToList();
            var maxSameReelItemNum = slotReelItems.Count;
            var isAllSameItems = itemGroupList.Any(item => item.Cnt == maxSameReelItemNum);
            var isAllItemOnlyOne = itemGroupList.All(slotItem => slotItem.Cnt == 1);

            if (isAllSameItems)
            {
                return slotReelItems;
            }

            if (isAllItemOnlyOne)
            {
                return Enumerable.Repeat(ReelItem.NoThisItem, slotReelItems.Count).ToList();
            }

            // replace some items to match prize in prize pool
            foreach (var theItem in itemGroupList)
            {
                var isItemOnlyOneAndNotWild = (theItem.Cnt == 1 && theItem.Item != ReelItem.Wild);

                if (isItemOnlyOneAndNotWild)
                {
                    slotReelItems[slotReelItems.FindIndex(index => index.Equals(theItem.Item))] = ReelItem.NoThisItem;
                }
            }

            return slotReelItems;
        }

        private static int GetPrizeScore(List<ReelItem> slotReelItems)
        {
            slotReelItems = GetPrizeFilterReelItems(slotReelItems);

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
                {new List<ReelItem>(){ReelItem.Jack, ReelItem.Jack, ReelItem.Wild},  2},

                { new List<ReelItem>(){ReelItem.Wild, ReelItem.Wild, ReelItem.NoThisItem},  10},
                { new List<ReelItem>(){ReelItem.Star, ReelItem.Star, ReelItem.NoThisItem},  9},
                { new List<ReelItem>(){ReelItem.Bell, ReelItem.Bell, ReelItem.NoThisItem},  8},
                { new List<ReelItem>(){ReelItem.Shell, ReelItem.Shell, ReelItem.NoThisItem},  7},
                { new List<ReelItem>(){ReelItem.Seven, ReelItem.Seven, ReelItem.NoThisItem},  6},
                { new List<ReelItem>(){ReelItem.Cherry, ReelItem.Cherry, ReelItem.NoThisItem},  5},
                { new List<ReelItem>(){ReelItem.Bar, ReelItem.Bar, ReelItem.NoThisItem},  4},
                { new List<ReelItem>(){ReelItem.King, ReelItem.King, ReelItem.NoThisItem},  3},
                { new List<ReelItem>(){ReelItem.Queen, ReelItem.Queen, ReelItem.NoThisItem},  2},
                { new List<ReelItem>(){ReelItem.Jack, ReelItem.Jack, ReelItem.NoThisItem},  1},

                { new List<ReelItem>(){ReelItem.NoThisItem, ReelItem.NoThisItem, ReelItem.NoThisItem},  0}
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