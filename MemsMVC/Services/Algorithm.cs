using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemsMVC.Services
{
    public class Algorithm
    {
        /* winner, loser = текущие рейтинги картинок
         * 
         * return (новые рейтинги победителя,  проигравшего)
         */
        public static List<double> updateR(double winner, double loser)
        {
            double e_winner = 1 / (1 + Math.Pow(10, (loser - winner) / 400));
            double e_loser = 1 / (1 + Math.Pow(10, (winner - loser) / 400));

            int k_winner = getK(winner);
            int k_loser = getK(loser);


            double new_winner = winner + k_winner * (1 - e_winner);
            double new_loser = loser + k_loser * (0 - e_loser);
            var list = new List<double>();
            list.Add(new_winner);
            list.Add(new_loser);
            return list;
        }
        private static int getK(double r)
        {
            if (r >= 2400) return 10;
            if (r >= 2300) return 20;
            return 40;
        }

    }
}
