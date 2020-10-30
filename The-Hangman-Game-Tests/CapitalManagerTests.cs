using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Hangman_Game;

namespace The_Hangman_Game_Tests
{
    [TestClass]
    public class CapitalManagerTests
    {
        [TestMethod]
        public void CapitalManagerIsCreated()
        {
            var _capitalManager = new CapitalManager();
            Assert.IsNotNull(_capitalManager);
        }

        [TestMethod]
        public void CapitalsListIsCreated()
        {
            var _capitalManager = new CapitalManager();
            Assert.IsNotNull(_capitalManager._listCapitals);
        }

        [TestMethod]
        public void LoadDataFromText()
        {
            var _capitalManager = new CapitalManager();

            Assert.IsNotNull(_capitalManager);
        }

        [TestMethod]
        public void CapitalListLoadAllRows()
        {
            var _capitalManager = new CapitalManager();

            Assert.IsNotNull(_capitalManager._listCapitals);
            Assert.AreEqual(183, _capitalManager._listCapitals.Count);
        }

        [TestMethod]
        public void RandomizeCapitalFromList()
        {
            var _capitalManager = new CapitalManager();

            Assert.IsNotNull(_capitalManager.SelectRandomCapital());
            Assert.IsInstanceOfType(_capitalManager.SelectRandomCapital(), typeof(Capital));
        }
    }
}
