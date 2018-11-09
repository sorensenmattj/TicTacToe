using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        public char[] State { get; private set; }

        public readonly char[] ValidTokens = { 'X', 'O' };

        private const char _emptyCell = ' ';

        private readonly Dictionary<string, int> _coordIndexMap;

        /// <summary>
        /// Initialise a new instance of the <see cref="Board"/> class.
        /// </summary>
        public Board()
        {
            State = Enumerable.Repeat(_emptyCell, 9).ToArray();

            _coordIndexMap = 
                new Dictionary<string, int>
                {
                    { "1,1", 6 },
                    { "1,2", 3 },
                    { "1,3", 0 },
                    { "2,1", 7 },
                    { "2,2", 4 },
                    { "2,3", 1 },
                    { "3,1", 8 },
                    { "3,2", 5 },
                    { "3,3", 2 },
                };
        }

        /// <summary>
        /// Place a token on the board.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the index is out of range of the board.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if an invalid token is provided,
        /// or if there is already a token at the
        /// provided index.
        /// </exception>
        public void PlaceToken(char token, int index)
        {
            CheckIndex(index);
            CheckToken(token);

            State[index] = token;
        }

        /// <summary>
        /// Check that the provided index is a valid index.
        /// </summary>
        private void CheckIndex(int index)
        {
            if (index < 0 || index > State.Length - 1)
            {
                var message =
                    $"Provided index must be between 0 and {State.Length - 1}.";
                throw new ArgumentOutOfRangeException(nameof(index), message);
            }
            else if (State[index] != _emptyCell)
            {
                var message = "Token already placed at this position.";
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Check that the provided token is a valid token.
        /// </summary>
        private void CheckToken(char token)
        {
            if (!ValidTokens.Contains(token))
            {
                var messageBuilder = new StringBuilder();

                messageBuilder.Append($"Invalid token provided. Valid tokens are {ValidTokens[0]}");

                for (int i = 1; i < ValidTokens.Length; i++)
                {
                    messageBuilder.Append($" and {ValidTokens[i]}");
                }

                messageBuilder.Append(".");

                throw new ArgumentException(messageBuilder.ToString());
            }
        }

        /// <summary>
        /// Get the index corresponding to the provided coordinates.
        /// </summary>
        public int GetIndexFromCoords(string coords)
        {
            try
            {
                return _coordIndexMap[coords];
            }
            catch (KeyNotFoundException)
            {
                var message = "Provided coordinates are invalid.";
                throw new ArgumentException(message);
            }
        }
    }
}
