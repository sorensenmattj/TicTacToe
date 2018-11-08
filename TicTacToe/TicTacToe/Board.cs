using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        public char[] State { get; set; }

        public char[] ValidTokens => new char[] { 'X', 'O' };

        /// <summary>
        /// Initialise a new instance of the <see cref="Board"/> class.
        /// </summary>
        public Board()
        {
            State = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
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
            if (index < 0 || index > State.Length - 1)
            {
                var message =
                    $"Provided index must be between 0 and {State.Length - 1}.";
                throw new ArgumentOutOfRangeException(nameof(index), message);
            }

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

            State[index] = token;
        }
    }
}
