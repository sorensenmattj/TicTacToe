using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using TicTacToe;

namespace UnitTests
{
    [TestFixture]
    public class GameMechanics
    {
        private Engine _engine;
        private Board _board;
        private Display _display;

        [SetUp]
        public void SetUp()
        {
            _engine = new Engine();
            _board = new Board();
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

        [TestCase('X', new int[] { 0, 1, 2 })]
        [TestCase('X', new int[] { 3, 4, 5 })]
        [TestCase('X', new int[] { 6, 7, 8 })]
        [TestCase('O', new int[] { 0, 1, 2 })]
        [TestCase('O', new int[] { 3, 4, 5 })]
        [TestCase('O', new int[] { 6, 7, 8 })]
        public void CheckHorizontalWin(char token, int[] tokenPlacements)
        {
            foreach (var index in tokenPlacements)
            {
                _board.PlaceToken(token, index);
            }

            var actualHasWon = _board.HasPlayerWon(token);

            Assert.IsTrue(
                actualHasWon,
                "Board returned false for win when win expected.");
        }

        [TestCase]
        public void CheckNoWinOnEmptyCells()
        {
            var actualHasWon = _board.HasPlayerWon(' ');

            Assert.IsFalse(
                actualHasWon,
                "Board returned win when no win expected.");
        }

        [TestCase('X', new int[] { 0, 3, 6 })]
        [TestCase('X', new int[] { 1, 4, 7 })]
        [TestCase('X', new int[] { 2, 5, 8 })]
        [TestCase('O', new int[] { 0, 3, 6 })]
        [TestCase('O', new int[] { 1, 4, 7 })]
        [TestCase('O', new int[] { 2, 5, 8 })]
        public void CheckVerticalWin(char token, int[] tokenPlacements)
        {
            foreach (var index in tokenPlacements)
            {
                _board.PlaceToken(token, index);
            }

            var actualHasWon = _board.HasPlayerWon(token);

            Assert.IsTrue(
                actualHasWon,
                "Board returned false for win when win expected.");
        }

        [TestCase('X', new int[] { 0, 4, 8 })]
        [TestCase('X', new int[] { 2, 4, 6 })]
        [TestCase('O', new int[] { 0, 4, 8 })]
        [TestCase('O', new int[] { 2, 4, 6 })]
        public void CheckDiagonalWin(char token, int[] tokenPlacements)
        {
            foreach (var index in tokenPlacements)
            {
                _board.PlaceToken(token, index);
            }

            var actualHasWon = _board.HasPlayerWon(token);

            Assert.IsTrue(
                actualHasWon,
                "Board returned false for win when win expected.");
        }

        [TestCase]
        public void PrintBoard()
        {
            var outputBuilder = new StringBuilder();
            var writer = new StringWriter(outputBuilder);

            _display = new Display(writer, _board.NumberOfColumns);

            _display.Show(_board.State);

            var expectedBuilder = new StringBuilder();
            expectedBuilder.AppendLine("   |   |   ");
            expectedBuilder.AppendLine("   |   |   ");
            expectedBuilder.AppendLine("   |   |   ");
            expectedBuilder.AppendLine("--- --- ---");
            expectedBuilder.AppendLine("   |   |   ");
            expectedBuilder.AppendLine("   |   |   ");
            expectedBuilder.AppendLine("   |   |   ");
            expectedBuilder.AppendLine("--- --- ---");
            expectedBuilder.AppendLine("   |   |   ");
            expectedBuilder.AppendLine("   |   |   ");
            expectedBuilder.AppendLine("   |   |   ");
            expectedBuilder.AppendLine();

            Assert.AreEqual(
                expectedBuilder.ToString(),
                outputBuilder.ToString(),
                "Actual showing of board does not match expected showing.");
        }
    }
}
