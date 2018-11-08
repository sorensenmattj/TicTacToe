using NUnit.Framework;
using System;
using TicTacToe;

namespace UnitTests
{
    [TestFixture]
    public class BoardInteraction
    {
        private Board _board;

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
        }

        [TestCase]
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

        [TestCase('X', 0, new char[] { 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' })]
        [TestCase('X', 1, new char[] { ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ' })]
        [TestCase('X', 2, new char[] { ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ' })]
        [TestCase('X', 3, new char[] { ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ' })]
        [TestCase('X', 4, new char[] { ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ' })]
        [TestCase('X', 5, new char[] { ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ' })]
        [TestCase('X', 6, new char[] { ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ' })]
        [TestCase('X', 7, new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ' })]
        [TestCase('X', 8, new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X' })]
        [TestCase('O', 0, new char[] { 'O', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' })]
        [TestCase('O', 1, new char[] { ' ', 'O', ' ', ' ', ' ', ' ', ' ', ' ', ' ' })]
        [TestCase('O', 2, new char[] { ' ', ' ', 'O', ' ', ' ', ' ', ' ', ' ', ' ' })]
        [TestCase('O', 3, new char[] { ' ', ' ', ' ', 'O', ' ', ' ', ' ', ' ', ' ' })]
        [TestCase('O', 4, new char[] { ' ', ' ', ' ', ' ', 'O', ' ', ' ', ' ', ' ' })]
        [TestCase('O', 5, new char[] { ' ', ' ', ' ', ' ', ' ', 'O', ' ', ' ', ' ' })]
        [TestCase('O', 6, new char[] { ' ', ' ', ' ', ' ', ' ', ' ', 'O', ' ', ' ' })]
        [TestCase('O', 7, new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'O', ' ' })]
        [TestCase('O', 8, new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'O' })]
        public void PlaceToken(char token, int index, char[] expectedState)
        {
            char[] boardState;

            _board.PlaceToken(token, index);

            boardState = _board.State;

            for (int i = 0; i < expectedState.Length; i++)
            {
                Assert.AreEqual(expectedState[i], boardState[i]);
            }
        }

        [TestCase(-1)]
        [TestCase(9)]
        public void PlaceTokenAtInvalidIndex(int invalidIndex)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _board.PlaceToken('X', invalidIndex));

            try
            {
                _board.PlaceToken('X', invalidIndex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                var messageParts = 
                    ex.Message.Split(
                        Environment.NewLine.ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries);

                var message = messageParts[0];
                var parameterName = messageParts[1];

                Assert.AreEqual(
                    "Provided index must be between 0 and 8.",
                    message);

                Assert.AreEqual("Parameter name: index", parameterName);
            }
        }

        [TestCase('A')]
        [TestCase('Z')]
        public void PlaceInvalidToken(char invalidToken)
        {
            Assert.Throws<ArgumentException>(
                () => _board.PlaceToken(invalidToken, 0));

            try
            {
                _board.PlaceToken(invalidToken, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(
                    "Invalid token provided. Valid tokens are X and O.",
                    ex.Message);
            }
        }

        [TestCase('X', 0)]
        [TestCase('X', 1)]
        [TestCase('X', 2)]
        [TestCase('X', 3)]
        [TestCase('X', 4)]
        [TestCase('X', 5)]
        [TestCase('X', 6)]
        [TestCase('X', 7)]
        [TestCase('X', 8)]
        [TestCase('O', 0)]
        [TestCase('O', 1)]
        [TestCase('O', 2)]
        [TestCase('O', 3)]
        [TestCase('O', 4)]
        [TestCase('O', 5)]
        [TestCase('O', 6)]
        [TestCase('O', 7)]
        [TestCase('O', 8)]
        public void PlaceTokenInOccupiedIndex(char token, int index)
        {
            _board.PlaceToken(token, index);

            Assert.Throws<ArgumentException>(
                () => _board.PlaceToken(token, index));

            try
            {
                _board.PlaceToken(token, index);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(
                    "Token already placed at this position.",
                    ex.Message);
            }
        }
    }
}
