using System;
using NUnit.Framework;
using TicTacToe;

namespace UnitTests
{
    [TestFixture]
    public class GameMechanics
    {
        private Engine _engine;

        [SetUp]
        public void SetUp()
        {
            _engine = new Engine();
        }

        [TestCase]
        public void GetFirstPlayerToken()
        {
            var expectedFirstToken = 'X';
            var actualFirstToken = _engine.CurrentToken;

            Assert.AreEqual(
                expectedFirstToken,
                actualFirstToken,
                "The returned current token does not match the expected token.");
        }

        [TestCase(1, 'O')]
        [TestCase(2, 'X')]
        [TestCase(3, 'O')]
        [TestCase(4, 'X')]
        [TestCase(5, 'O')]
        [TestCase(6, 'X')]
        [TestCase(7, 'O')]
        [TestCase(8, 'X')]
        [TestCase(9, 'O')]
        public void GetCurrentTokenAfterMoves(int numberOfMoves, char expectedToken)
        {
            for (int i = 0; i < numberOfMoves; i++)
            {
                _engine.TurnNumber++;
            }

            var actualToken = _engine.CurrentToken;
            Assert.AreEqual(
                expectedToken,
                actualToken,
                "The returned current token does not match the expected token.");
        }
    }
}
