using Badges.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestBadges
{
    [TestClass]
    public class UnitTest1
    {
        private BadgeRepo _repo = new BadgeRepo();
        System.Collections.Generic.List<string> _list1 = new List<string>();
        Dictionary<string, List<string>> badgeDictionary = new Dictionary<string, List<string>>();
        private List<Badge> _badgeDirectory = new List<Badge>();

        [TestMethod]
        public void AddBadgeGetCount()
        {
            _repo.DictionarySeed();

            int expected = 4;
            int actual = _repo.GetBadgeList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBadgeCountShouldIncrease()
        {

            Badge a1 = new Badge("A1", _list1);
            _list1.Add("B1");
            _list1.Add("B2");

            bool wasAdded = _repo.AddBadgeToDirectory(a1);

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void GetBadgeByIDShouldGetBadge()
        {
            Badge a1 = new Badge("A1", _list1);
            _list1.Add("B1");
            _list1.Add("B2");

            _repo.AddBadgeToDirectory(a1);
            Badge testBadge = _repo.GetBadgeByID("A1");

            Assert.AreEqual(a1, testBadge);
        }

        [TestMethod]
        public void UpdateBadgeShouldUpdate()
        {
            Badge badgeToUpdate = new Badge("A4", new List<string> { "B3", "B4" });
            _repo.AddBadgeToDirectory(badgeToUpdate);

            Badge newBadge = new Badge("A6", new List<string> { "B1", "B2" });
            _repo.UpdateBadgeByID("A4", newBadge);

            string expectedValue = "A6";
            string actualValue = _repo.GetBadgeByID("A6").BadgeID;
            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void UpdateDictionaryShouldUpdate()
        {

            _repo.DictionarySeed();

            List<Badge> listOfBadges = _repo.GetBadgeList();
            foreach (Badge line in listOfBadges)
            {
                badgeDictionary.Add(line.BadgeID, line.DoorNames);
            }



            bool expected = true;
            bool actual = false;
            if (badgeDictionary.ContainsKey("A1"))
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
