using System;

namespace PlayerManager3
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
        public int CompareTo(Player other)
        {
            if (other == null) return 1;
            return other.Score - this.Score;
        }

    }
}