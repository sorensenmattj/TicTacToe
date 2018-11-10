using System;

namespace TicTacToe
{
    public static class Start
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Play(Console.Out, Console.In);

            Console.Read();
        }
    }
}
