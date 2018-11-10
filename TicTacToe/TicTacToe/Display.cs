using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Display
    {
        private readonly TextWriter _writer;
        private readonly int _numberOfColumns;

        public Display(TextWriter writer, int numberOfColumns)
        {
            _writer = writer;
            _numberOfColumns = numberOfColumns;
        }

        public void Show(char[] boardState)
        {
            var fillerLine = "   |   |   ";
            var dividerLine = "--- --- ---";
            var numberOfRows = boardState.Length / _numberOfColumns;

            for (int i = 0; i < numberOfRows; i++)
            {
                _writer.WriteLine(fillerLine);

                var tokenLine = new StringBuilder();

                for (int j = 0; j < _numberOfColumns; j++)
                {
                    tokenLine.Append($" {boardState[_numberOfColumns * i + j]} ");

                    if (j != _numberOfColumns - 1)
                    {
                        tokenLine.Append("|");
                    }
                }

                _writer.WriteLine(tokenLine.ToString());
                _writer.WriteLine(fillerLine);
                
                if (i != numberOfRows - 1)
                {
                    _writer.WriteLine(dividerLine);
                }
            }

            _writer.WriteLine();
        }
    }
}
