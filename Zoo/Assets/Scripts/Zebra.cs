using UnityEngine;

namespace Zoo
{
    class Zebra : Animal, IHerbivore
    {
        protected override string GetHelloMessage()
        {
            return "zebra zebra";
        }

        public void EatLeaves()
        {
            Speak("munch munch zank yee bra");
        }
    }
}
