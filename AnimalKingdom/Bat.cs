using System;
using Polimorfismo;

namespace AnimalKingdom
{
    public class Bat : Animal, ICanFly
    {
        public int NumberOfNipples { get;} = 2;
        public int NumberOfWings { get;} = 2;
        public override string Sound()
    

        {
        return base.Sound() + "NIck Nick";
    
        }
    }
}