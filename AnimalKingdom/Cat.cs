using System;
using AnimalKingdom;

namespace Polimorfismo
{
    public class Cat : Animal, IMammal
    {
        public int NumberOfNipples { get; } = 6;
        public override string Sound()
        {
            return base.Sound() + "Miau";
        }
    }
}
