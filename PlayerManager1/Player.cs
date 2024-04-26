using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager1
{
    public class Player
    {
        public string Name { get; }
        public int Score { get; private set;}

        public Player(string _name, int _score)
        {
            Name = _name;
            Score = _score;
        }

    }
}