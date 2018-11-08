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
