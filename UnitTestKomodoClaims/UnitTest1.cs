using KomodoClaims.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestKomodoClaims
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimRepo _repo = new ClaimRepo();

        public void Seed()
        {
            Claim Jenna = new Claim("460", ClaimType.HomeBurglary, "Stolen pancakes.", 1000.00m, new DateTime(2021, 11, 25), new DateTime(2021, 12, 05), true);

            Claim Milly = new Claim("461", ClaimType.CustomerInjury, "My professor hit me with his car.", 1000.00m, new DateTime(2021, 12, 14), new DateTime(2021, 12, 18), true);

            Claim Nick = new Claim("462", ClaimType.HomeFire, "One of my students set my home on fire, and while I tried to back out of my driveway to save my car, I ran him over.", 1000.00m, new DateTime(2021, 12, 14), new DateTime(2021, 12, 18), true);

            _repo.AddClaimToDirectory(Jenna);
            _repo.AddClaimToDirectory(Milly);
            _repo.AddClaimToDirectory(Nick);
        }

        [TestMethod]
        public void AddClaimGetCount()
        {
            Seed();

            int expected = 3;
            int actual = _repo.GetContents().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddClaimCountShouldIncrease()
        {
            Claim Jenna = new Claim("460", ClaimType.HomeBurglary, "Stolen pancakes.", 1000.00m, new DateTime(2021, 11, 25), new DateTime(2021, 12, 05), true);

            bool wasAdded = _repo.AddClaimToDirectory(Jenna);

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void GetClaimByIDShouldGetClaim()
        {
            Claim Jenna = new Claim("460", ClaimType.HomeBurglary, "Stolen pancakes.", 1000.00m, new DateTime(2021, 11, 25), new DateTime(2021, 12, 05), true);

            _repo.AddClaimToDirectory(Jenna);
            Claim testClaim = _repo.GetClaimByID("123KB");


            Assert.AreEqual(Jenna, testClaim);
        }

        [TestMethod]
        public void UpdateClaimShouldUpdate()
        {

            Seed();
            Claim newContent = new Claim("460", ClaimType.HomeBurglary, "Stolen pancakes.", 1000.00m, new DateTime(2021, 11, 25), new DateTime(2021, 12, 05), false);
            _repo.UpdateClaimByID("123KB", newContent);

            bool expected = false;
            bool actual = _repo.GetClaimByID("460").IsValid;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void RemoveClaimShouldRemove()
        {
            Seed();

            _repo.RemoveClaimByID("460");
            int expected = 2;
            int actual = _repo.GetContents().Count;
            Assert.AreEqual(expected, actual);

        }
    }
}
