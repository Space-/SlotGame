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

        [SetUp]
        public void InitSlotMachineReels()
        {
            var reel = GetReelItems();
            _threeSameReelItems = new List<ReelItem[]> { reel, reel, reel };
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

        private static void GameResultShouldBe(int expected)
        {
            var slotMachine = new SlotMachine();
            var slotScore = slotMachine.GetSlotScore(_threeSameReelItems, _spinIndexes);
            Assert.AreEqual(expected, slotScore);
        }

        private static ReelItem[] GetReelItems()
        {
            return Enum.GetValues(typeof(ReelItem)).Cast<ReelItem>().ToArray();
        }
    }
}