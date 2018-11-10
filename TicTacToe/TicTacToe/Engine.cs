using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Engine
    {
        private readonly Board _board;

        public char CurrentToken => _board.ValidTokens[TurnNumber % 2];

        public int TurnNumber { get; set; }

        /// <summary>
        /// Initialise a new instance of the <see cref="Engine"/> class.
        /// </summary>
        public Engine()
        {
            _board = new Board();
        }
        
        /// <summary>
        /// Get the coordinates from the user.
        /// </summary>
        public string GetCoordinates(TextWriter writer, TextReader reader)
        {
            writer.Write("x-coord: ");
            var xCoord = reader.ReadLine();

            writer.Write("y-coord: ");
            var yCoord = reader.ReadLine();

            var coords = $"{xCoord},{yCoord}";

            return coords;
        }
    }
}
