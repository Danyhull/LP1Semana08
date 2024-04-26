using System;

namespace PlayerManager2
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