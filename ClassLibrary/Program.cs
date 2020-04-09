using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Program
    {

        public Program() { }

        // This method will check who is the winner
        // if the number that is parsed to the function is greater than the second, the first one is the winner
        // viceversa, first player is the loser
        // if the numbers are equal, than a draw occurred
        public  void checkWinner(int a, int b, Player player1, Player player2)
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
