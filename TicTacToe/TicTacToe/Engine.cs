using System;
using System.IO;

namespace TicTacToe
{
    public class Engine
    {
        private readonly Board _board;

        private readonly Display _display;

        public char CurrentToken => _board.ValidTokens[(TurnNumber - 1) % 2];

        public int TurnNumber { get; set; }

        private int MaxTurnNumber => _board.State.Length;

        /// <summary>
        /// Initialise a new instance of the <see cref="Engine"/> class.
        /// </summary>
        public Engine()
        {
            _board = new Board();
            _display = new Display(Console.Out, _board.NumberOfColumns);
            TurnNumber = 1;
        }

        /// <summary>
        /// Runs the game.
        /// </summary>
        public void Play(TextWriter writer, TextReader reader)
        {
            while (TurnNumber <= MaxTurnNumber)
            {
                _display.Show(_board.State);

                while (true)
                {
                    writer.WriteLine($"{CurrentToken}'s turn.");
                    var coords = GetCoordinates(writer, reader);

                    try
                    {
                        var index = _board.GetIndexFromCoords(coords);

                        _board.PlaceToken(CurrentToken, index);
                    }
                    catch (ArgumentException ex)
                    {
                        var message = ex.Message
                                        .Split(
                                            Environment.NewLine.ToCharArray(),
                                            StringSplitOptions.RemoveEmptyEntries)[0];

                        writer.WriteLine(message);

                        continue;
                    }

                    break;
                }

                if (_board.HasPlayerWon(CurrentToken))
                {
                    _display.Show(_board.State);

                    writer.WriteLine($"{CurrentToken} has won!");
                    break;
                }

                TurnNumber++;
            }
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

            writer.WriteLine();

            return coords;
        }
    }
}
