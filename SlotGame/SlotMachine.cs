using System.Collections.Generic;
using System.Linq;

namespace SlotGameTest.cs
{
    public class SlotMachine
    {
        public int GetSlotScore(List<ReelItem[]> reelItems, int[] spinIndexes, ReelItem prizeReelItem)
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
                { Enumerable.Repeat(ReelItem.Star, itemRepeatTimes).ToList(), 90 }
            };

            return prizePool[slotReelItems];
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