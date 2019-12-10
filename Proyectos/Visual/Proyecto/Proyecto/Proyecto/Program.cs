using System;
using System.Collections.Generic;

namespace Proyecto
{
    class Program
    {
        static String[] directions = { "W","S","A","D"};
        static void Main(string[] args)
        {
            List <Arrow>  simonMoves = new List<Arrow> { };
            simonMoves = GenerateMoves(simonMoves,4);
            DrawMoves(simonMoves);
            List<Arrow> playerMoves = new List<Arrow> { };
            playerMoves = InputMoves(playerMoves,4);
            CompareMoves(simonMoves,playerMoves);
            Console.ReadLine();

        }
        public static void CompareMoves(List<Arrow> simonMoves, List<Arrow> playerMoves) {
            int matches = 0;
            for (int i = 0; i < simonMoves.Count; i++)
            {
                if (simonMoves[i].GetSymbol() == playerMoves[i].GetSymbol()) {
                    matches++;
                }
            }
            Console.WriteLine("Aciertos totales: " + matches + " de " + simonMoves.Count + " posibles");
        }

        public static void DrawMoves(List<Arrow> simonMoves) {
            Console.WriteLine("Simon dice: ");
            Console.Write("Movimientos: ");
            foreach (Arrow move in simonMoves)
            {
                Console.Write(move.GetSymbol() + " ");
                System.Threading.Thread.Sleep(400);
            }
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }

        public static List<Arrow> InputMoves(List<Arrow> playerMoves, int totalMoves) {
            Console.WriteLine("Repite: ");
            int keyPressNumber = 0;
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                keyPressNumber++;
                string letter = keyinfo.Key.ToString().ToUpper();
                Console.Write(letter+" ");
                Arrow arrow = new Arrow(letter);
                playerMoves.Add(arrow);
            }
            while (keyPressNumber < totalMoves);
            Console.WriteLine(" ");
            return playerMoves;
        }


        public static List<Arrow> GenerateMoves(List<Arrow> simonMoves, int totalMoves) {
            if (simonMoves.Count < totalMoves)
            {
                simonMoves = GenerateMove(simonMoves);
                return GenerateMoves(simonMoves, totalMoves);
            }
            else {
                return simonMoves;
            }
        }

        public static List<Arrow> GenerateMove(List<Arrow> simonMoves)
        {
            Random moveRoll = new Random();
            System.Threading.Thread.Sleep(100);
            int roll = moveRoll.Next(1, directions.Length);
            Arrow move = new Arrow(directions[roll]);
            simonMoves.Add(move);
            return simonMoves;
        }

    }

    internal class Arrow
    {
        private string symbol = "";

        public Arrow(string symbol) {
            this.symbol = symbol;     
        }

        public string GetSymbol()
        {
            return symbol;
        }
    }
}
