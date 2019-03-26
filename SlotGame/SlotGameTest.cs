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
            _threeSameReelItems = new List<ReelItem[]> { _reel, _reel, _reel };
        }

        [Test]
        public void Reels_same_order_three_Wild_return_100()
        {
            _spinIndexes = GetIndexesArrayFromSameKey(ReelItem.Wild);
            GameResultShouldBe(100);
        }

        private static int[] GetIndexesArrayFromSameKey(ReelItem item)
        {
            var itemIndexInReel = Array.IndexOf(_reel, item);
            const int totalNumOfReels = 3;
            return Enumerable.Repeat(itemIndexInReel, totalNumOfReels).ToArray();
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

        [Test]
        public void Reels_same_order_two_Star_one_Wild_return_18()
        {
            _spinIndexes = new[] { (int)ReelItem.Star, (int)ReelItem.Wild, (int)ReelItem.Star };
            GameResultShouldBe(18);
        }

        [Test]
        public void Reels_same_order_two_Bell_one_Wild_return_16()
        {
            _spinIndexes = new[] { (int)ReelItem.Bell, (int)ReelItem.Wild, (int)ReelItem.Bell };
            GameResultShouldBe(16);
        }

        [Test]
        public void Reels_same_order_two_Shell_one_Wild_return_14()
        {
            _spinIndexes = new[] { (int)ReelItem.Shell, (int)ReelItem.Wild, (int)ReelItem.Shell };
            GameResultShouldBe(14);
        }

        [Test]
        public void Reels_same_order_two_Seven_one_Wild_return_12()
        {
            _spinIndexes = new[] { (int)ReelItem.Seven, (int)ReelItem.Wild, (int)ReelItem.Seven };
            GameResultShouldBe(12);
        }

        [Test]
        public void Reels_same_order_two_Cherry_one_Wild_return_10()
        {
            _spinIndexes = new[] { (int)ReelItem.Cherry, (int)ReelItem.Wild, (int)ReelItem.Cherry };
            GameResultShouldBe(10);
        }

        [Test]
        public void Reels_same_order_two_Bar_one_Wild_return_8()
        {
            _spinIndexes = new[] { (int)ReelItem.Bar, (int)ReelItem.Wild, (int)ReelItem.Bar };
            GameResultShouldBe(8);
        }

        [Test]
        public void Reels_same_order_two_King_one_Wild_return_6()
        {
            _spinIndexes = new[] { (int)ReelItem.King, (int)ReelItem.Wild, (int)ReelItem.King };
            GameResultShouldBe(6);
        }

        [Test]
        public void Reels_same_order_two_Queen_one_Wild_return_4()
        {
            _spinIndexes = new[] { (int)ReelItem.Queen, (int)ReelItem.Wild, (int)ReelItem.Queen };
            GameResultShouldBe(4);
        }

        [Test]
        public void Reels_same_order_two_Jack_one_Wild_return_2()
        {
            _spinIndexes = new[] { (int)ReelItem.Jack, (int)ReelItem.Wild, (int)ReelItem.Jack };
            GameResultShouldBe(2);
        }

        [Test]
        public void Reels_same_order_two_Wild_one_other_return_10()
        {
            _spinIndexes = new[] { (int)ReelItem.Wild, (int)ReelItem.Wild, (int)ReelItem.Jack };
            GameResultShouldBe(10);
        }

        [Test]
        public void Reels_same_order_two_Star_one_other_return_9()
        {
            _spinIndexes = new[] { (int)ReelItem.Star, (int)ReelItem.Star, (int)ReelItem.Jack };
            GameResultShouldBe(9);
        }

        [Test]
        public void Reels_same_order_two_Bell_one_other_return_8()
        {
            _spinIndexes = new[] { (int)ReelItem.Bell, (int)ReelItem.Bell, (int)ReelItem.Jack };
            GameResultShouldBe(8);
        }

        [Test]
        public void Reels_same_order_two_Shell_one_other_return_7()
        {
            _spinIndexes = new[] { (int)ReelItem.Shell, (int)ReelItem.Shell, (int)ReelItem.Jack };
            GameResultShouldBe(7);
        }

        [Test]
        public void Reels_same_order_two_Seven_one_other_return_6()
        {
            _spinIndexes = new[] { (int)ReelItem.Seven, (int)ReelItem.Seven, (int)ReelItem.Jack };
            GameResultShouldBe(6);
        }

        [Test]
        public void Reels_same_order_two_Cherry_one_other_return_5()
        {
            _spinIndexes = new[] { (int)ReelItem.Cherry, (int)ReelItem.Cherry, (int)ReelItem.Jack };
            GameResultShouldBe(5);
        }

        [Test]
        public void Reels_same_order_two_Bar_one_other_return_4()
        {
            _spinIndexes = new[] { (int)ReelItem.Bar, (int)ReelItem.Bar, (int)ReelItem.Jack };
            GameResultShouldBe(4);
        }

        [Test]
        public void Reels_same_order_two_King_one_other_return_3()
        {
            _spinIndexes = new[] { (int)ReelItem.King, (int)ReelItem.King, (int)ReelItem.Jack };
            GameResultShouldBe(3);
        }

        [Test]
        public void Reels_same_order_two_Queen_one_other_return_2()
        {
            _spinIndexes = new[] { (int)ReelItem.Queen, (int)ReelItem.Queen, (int)ReelItem.Jack };
            GameResultShouldBe(2);
        }

        [Test]
        public void Reels_same_order_two_Jack_one_other_return_1()
        {
            _spinIndexes = new[] { (int)ReelItem.Jack, (int)ReelItem.Jack, (int)ReelItem.Star };
            GameResultShouldBe(1);
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
            GameResultShouldBe(1, threeDiffReelItems);
        }

        [Test]
        public void Reels_same_order_no_this_prize_Case1_one_Jack_one_Wild_one_Star_return_0()
        {
            _spinIndexes = new[] { (int)ReelItem.Jack, (int)ReelItem.Wild, (int)ReelItem.Star };
            GameResultShouldBe(0);
        }

        [Test]
        public void Reels_same_order_no_this_prize_Case2_one_Star_one_Bell_one_Shell_return_0()
        {
            _spinIndexes = new[] { (int)ReelItem.Star, (int)ReelItem.Bell, (int)ReelItem.Shell };
            GameResultShouldBe(0);
        }

        private static void GameResultShouldBe(int expected)
        {
            ValidateResult(expected, _threeSameReelItems);
        }

        private static void GameResultShouldBe(int expected, List<ReelItem[]> threeDiffReelItems)
        {
            ValidateResult(expected, threeDiffReelItems);
        }

        private static void ValidateResult(int expected, List<ReelItem[]> reelItems)
        {
            var slotMachine = new SlotMachine();
            var slotScore = slotMachine.GetSlotScore(reelItems, _spinIndexes);
            Assert.AreEqual(expected, slotScore);
        }

        private static ReelItem[] GetReelItems()
        {
            return Enum.GetValues(typeof(ReelItem)).Cast<ReelItem>().ToArray();
        }
    }
}