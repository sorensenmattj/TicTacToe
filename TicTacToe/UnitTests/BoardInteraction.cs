using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace UnitTests
{
    [TestClass]
    public class BoardInteraction
    {
        private Board _board;

        [TestInitialize]
        public void SetUp()
        {
            _board = new Board();
        }

        [TestMethod]
        public void EmptyBoard()
        {
            char[] boardState = _board.State;
            char[] expectedState =
                new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

            for (int i = 0; i < expectedState.Length; i++)
            {
                Assert.AreEqual(expectedState[i], boardState[i]);
            }
        }
    }
}
