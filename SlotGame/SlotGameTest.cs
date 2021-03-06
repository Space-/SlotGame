using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SlotGameTest.cs
{
    public class SlotGameTest
    {
        private static List<ReelItem[]> _threeSameReelItems;
        private static int[] _spinIndexes;
        private static ReelItem[] _reel;

        [SetUp]
        public void InitSlotMachineReels()
        {
            _reel = GetReelItems();
        }

        [Test]
        public void Reels_same_order_three_Wild_return_100()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Wild);
            GameResultShouldBe(100, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_Star_return_90()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Star);
            GameResultShouldBe(90, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_Bell_return_80()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Bell);
            GameResultShouldBe(80, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_Shell_return_70()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Shell);
            GameResultShouldBe(70, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_Seven_return_60()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Seven);
            GameResultShouldBe(60, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_Cherry_return_50()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Cherry);
            GameResultShouldBe(50, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_Bar_return_40()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Bar);
            GameResultShouldBe(40, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_King_return_30()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.King);
            GameResultShouldBe(30, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_Queen_return_20()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Queen);
            GameResultShouldBe(20, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_three_Jack_return_10()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Jack);
            GameResultShouldBe(10, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Star_one_Wild_return_18()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Star, (int)ReelItem.Wild, (int)ReelItem.Star };
            GameResultShouldBe(18, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Bell_one_Wild_return_16()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Bell, (int)ReelItem.Wild, (int)ReelItem.Bell };
            GameResultShouldBe(16, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Shell_one_Wild_return_14()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Shell, (int)ReelItem.Wild, (int)ReelItem.Shell };
            GameResultShouldBe(14, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Seven_one_Wild_return_12()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Seven, (int)ReelItem.Wild, (int)ReelItem.Seven };
            GameResultShouldBe(12, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Cherry_one_Wild_return_10()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Cherry, (int)ReelItem.Wild, (int)ReelItem.Cherry };
            GameResultShouldBe(10, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Bar_one_Wild_return_8()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Bar, (int)ReelItem.Wild, (int)ReelItem.Bar };
            GameResultShouldBe(8, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_King_one_Wild_return_6()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.King, (int)ReelItem.Wild, (int)ReelItem.King };
            GameResultShouldBe(6, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Queen_one_Wild_return_4()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Queen, (int)ReelItem.Wild, (int)ReelItem.Queen };
            GameResultShouldBe(4, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Jack_one_Wild_return_2()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Jack, (int)ReelItem.Wild, (int)ReelItem.Jack };
            GameResultShouldBe(2, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Wild_one_other_return_10()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Wild, (int)ReelItem.Wild, (int)ReelItem.Jack };
            GameResultShouldBe(10, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Star_one_other_return_9()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Star, (int)ReelItem.Star, (int)ReelItem.Jack };
            GameResultShouldBe(9, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Bell_one_other_return_8()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Bell, (int)ReelItem.Bell, (int)ReelItem.Jack };
            GameResultShouldBe(8, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Shell_one_other_return_7()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Shell, (int)ReelItem.Shell, (int)ReelItem.Jack };
            GameResultShouldBe(7, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Seven_one_other_return_6()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Seven, (int)ReelItem.Seven, (int)ReelItem.Jack };
            GameResultShouldBe(6, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Cherry_one_other_return_5()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Cherry, (int)ReelItem.Cherry, (int)ReelItem.Jack };
            GameResultShouldBe(5, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Bar_one_other_return_4()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Bar, (int)ReelItem.Bar, (int)ReelItem.Jack };
            GameResultShouldBe(4, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_King_one_other_return_3()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.King, (int)ReelItem.King, (int)ReelItem.Jack };
            GameResultShouldBe(3, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Queen_one_other_return_2()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Queen, (int)ReelItem.Queen, (int)ReelItem.Jack };
            GameResultShouldBe(2, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_two_Jack_one_other_return_1()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Jack, (int)ReelItem.Jack, (int)ReelItem.Star };
            GameResultShouldBe(1, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_different_order_two_Jack_one_other_return_1()
        {
            var reel1 = new ReelItem[]
            {
                ReelItem.Wild, ReelItem.Star, ReelItem.Bell, ReelItem.Shell, ReelItem.Seven,
                ReelItem.Cherry, ReelItem.Bar, ReelItem.King, ReelItem.Queen, ReelItem.Jack
            };

            var reel2 = new ReelItem[]
            {
                ReelItem.Jack, ReelItem.Wild, ReelItem.Star, ReelItem.Bell, ReelItem.Shell,
                ReelItem.Seven, ReelItem.Cherry, ReelItem.Bar, ReelItem.King, ReelItem.Queen,
            };

            var reel3 = new ReelItem[]
            {
                ReelItem.Cherry, ReelItem.Bar, ReelItem.King, ReelItem.Queen, ReelItem.Jack,
                ReelItem.Wild, ReelItem.Star, ReelItem.Bell, ReelItem.Shell, ReelItem.Seven
            };

            var threeDiffReelItems = new List<ReelItem[]> { reel1, reel2, reel3 };

            _spinIndexes = new[] { Array.IndexOf(reel1, ReelItem.Jack), Array.IndexOf(reel2, ReelItem.Jack), Array.IndexOf(reel3, ReelItem.Star) };
            GameResultShouldBe(1, threeDiffReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_no_this_prize_Case1_one_Jack_one_Wild_one_Star_return_0()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Jack, (int)ReelItem.Wild, (int)ReelItem.Star };
            GameResultShouldBe(0, _threeSameReelItems, _spinIndexes);
        }

        [Test]
        public void Reels_same_order_no_this_prize_Case2_one_Star_one_Bell_one_Shell_return_0()
        {
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
            _spinIndexes = new[] { (int)ReelItem.Star, (int)ReelItem.Bell, (int)ReelItem.Shell };
            GameResultShouldBe(0, _threeSameReelItems, _spinIndexes);
        }

        private static void GameResultShouldBe(int expected, List<ReelItem[]> reelItems, int[] _spinIndexes)
        {
            var slotMachine = new SlotMachine();
            var slotScore = slotMachine.GetSlotScore(reelItems, _spinIndexes);
            Assert.AreEqual(expected, slotScore);
        }

        private static ReelItem[] GetReelItems()
        {
            return Enum.GetValues(typeof(ReelItem)).Cast<ReelItem>().ToArray();
        }

        private static int[] GetIndexesArrayFromSameKey(ReelItem item)
        {
            return Enumerable.Repeat(Array.IndexOf(_reel, item), _threeSameReelItems.Count).ToArray();
        }
    }
}