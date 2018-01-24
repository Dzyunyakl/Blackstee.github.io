using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemsMVC.Models;

namespace MemsMVC.Services
{
    public class MemeSetter
    {
        public static Meme _item1 { get; set; }
        public static Meme _item2 { get; set; }
        public static Meme _winner { get; set; }
        public static Meme _loser { get; set; }
        public MemeSetter(Meme item1, Meme item2)
        {
            _item1 = item1;
            _item2 = item2;
        }
    }
}
