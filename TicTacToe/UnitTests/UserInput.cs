using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using TicTacToe;

namespace UnitTests
{
    [TestFixture]
    public class UserInput
    {
        private Engine _engine;
        private Board _board;

        [SetUp]
        public void SetUp()
        {
            _engine = new Engine();
            _board = new Board();
        }

        [TestCase(1, 1, "1,1")]
        [TestCase(1, 2, "1,2")]
        [TestCase(1, 3, "1,3")]
        [TestCase(2, 1, "2,1")]
        [TestCase(2, 2, "2,2")]
        [TestCase(2, 3, "2,3")]
        [TestCase(3, 1, "3,1")]
        [TestCase(3, 2, "3,2")]
        [TestCase(3, 3, "3,3")]
        public void GetCoordinatesFromUser(
            int xCoord,
            int yCoord,
            string expectedCoords)
        {
            var reader = new StringReader($"{xCoord}\n{yCoord}");
            var textWriter = new StringWriter();

            var actualCoords = _engine.GetCoordinates(textWriter, reader);

            Assert.AreEqual(
                expectedCoords, 
                actualCoords, 
                "Coordinates returned do not match expected coordinates.");
        }

        [TestCase("1\n1")]
        [TestCase("1\n2")]
        public void PromptUserForCoordinates(string coordInput)
        {
            var expectedOutput = $"x-coord: y-coord: {Environment.NewLine}";

            var actualOutput = new StringBuilder();
            var textWriter = new StringWriter(actualOutput);
            var textReader = new StringReader(coordInput);

            _engine.GetCoordinates(textWriter, textReader);

            Assert.AreEqual(
                expectedOutput,
                actualOutput.ToString(),
                "Actual user prompts do not match expected prompts.");
        }

        [TestCase("1,1", 6)]
        [TestCase("1,2", 3)]
        [TestCase("1,3", 0)]
        [TestCase("2,1", 7)]
        [TestCase("2,2", 4)]
        [TestCase("2,3", 1)]
        [TestCase("3,1", 8)]
        [TestCase("3,2", 5)]
        [TestCase("3,3", 2)]
        public void GetIndexFromCoordinates(string coords, int expectedIndex)
        {
            var actualIndex = _board.GetIndexFromCoords(coords);

            Assert.AreEqual(
                expectedIndex,
                actualIndex,
                "Calculated index does not match expected index.");
        }

        [TestCase("")]
        [TestCase("1\n4")]
        [TestCase("a")]
        [TestCase("b\nc")]
        [TestCase("B\nD\n3")]
        [TestCase("0\n0\n0")]
        [TestCase("1\n0\n1")]
        public void TryGetIndexFromInvalidCoordinates(string invalidCoords)
        {
            void TryInvalidCoordinates() =>
                _board.GetIndexFromCoords(invalidCoords);

            Assert.Throws<ArgumentException>(TryInvalidCoordinates);

            try
            {
                TryInvalidCoordinates();
            }
            catch (ArgumentException ex)
            {
                var actualMessage = ex.Message;
                Assert.AreEqual(
                    "Provided coordinates are invalid.",
                    actualMessage,
                    "Actual exception message does not match expected.");
            }
        }
    }
}
