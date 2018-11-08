using System;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        public char[] State { get; set; }

        public char[] ValidTokens => new char[] { 'X', 'O' };

        private char _emptyCell = ' ';

        /// <summary>
        /// Initialise a new instance of the <see cref="Board"/> class.
        /// </summary>
        public Board()
        {
            State = Enumerable.Repeat(_emptyCell, 9).ToArray();
        }

        /// <summary>
        /// Place a token on the board.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the index is out of range of the board.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if an invalid token is provided.
        /// </exception>
        public void PlaceToken(char token, int index)
        {
            CheckIndex(index);
            CheckToken(token);

            State[index] = token;
        }

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
    }
}
