using System;
using System.Collections.Generic;

namespace PlayerManager4
{
    public class CompareByName : IComparer<Player>
    {
        bool _ascendOrder;

        public CompareByName(bool _ascendOrder)
        {
            this._ascendOrder = _ascendOrder;
        }
        public int Compare(Player x, Player y)
        {
            int result = string.Compare(x.Name, y.Name);
            return _ascendOrder ? -result : result;
        }
    }
}