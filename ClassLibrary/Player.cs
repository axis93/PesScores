using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary
{
    [Serializable]
    public class Player
    {
        private string path = @"C:\Users\simon\source\repos\PesScores\DataLayer\results.xml";
        private String name;
        private int win = 0;
        private int draw = 0;
        private int lose = 0;
        private int gs = 0;
        private int gt = 0;
        private int dr = 0;
        private int points = 0;

        public Player() { }

        public Player(string name, int win, int draw, int lose, int gs, int gt, int dr, int points)
        {
            this.name = name;
            this.win = win;
            this.draw = draw;
            this.lose = lose;
            this.gs = gs;
            this.gt = gt;
            this.dr = dr;
            this.points = points;
        }


        public String Name { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public int Gs { get; set; }
        public int Gt { get; set; }
        public int Dr { get; set; }
        public int Points { get; set; }

        public int calculatePoints(int win, int draw)
        {
            return 3 * win + draw * 1;
        }

        public int addGaols(int goalScored)
        {
            Gs += goalScored;

            return gs;
        }

        public int goalsTaken(int goalScored, Player player2)
        {
            player2.Gt += goalScored;
            return gt;
        }


        public void printResult(Player player, int result1, Player player2, int result2)
        {
            String wholeResult = "";
            wholeResult = "" + player.name + " " + result1 + " - " + result2 + " " + player2.name;
        }

        public void printBoard(Player player1, Player player2)
        {
            Console.WriteLine("Team \t\t  W \t D \t L \t GS \t GT \t Points \n");
            if (player1.Win > player2.Win)
            {
                Console.WriteLine(" " + player1.Name + "\t" + player1.win + "\t" + player1.dr + "\t" + player1.lose + "\t" + player1.gs + "\t" + player1.gt + "\t" + player1.dr + "\t" + player1.points + "\n");
            }
            else
            {
                Console.WriteLine(" " + player2.Name + "\t" + player2.win + "\t" + player2.dr + "\t" + player2.lose + "\t" + player2.gs + "\t" + player2.gt + "\t" + player2.dr + "\t" + player2.points + "\n");
            }
        }



        // This method will check who is the winner
        // if the number that is parsed to the function is greater than the second, the first one is the winner
        // viceversa, first player is the loser
        // if the numbers are equal, than a draw occurred
        public static void checkWinner(int a, int b, Player player1, Player player2)
        {
            if (a > b)
            {
                player1.Win += 1;
                player2.Lose += 1;
            }
            else if (a == b)
            {
                player1.Draw += 1;
                player2.Draw += 1;
            }
            else
            {
                player2.Win += 1;
                player1.Lose += 1;
            }
        }

    }
}
