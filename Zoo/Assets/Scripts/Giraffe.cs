using UnityEngine;

namespace Zoo
{
    class Giraffe : Animal, IHerbivore
    {
        protected override string GetHelloMessage()
        {
            return "hello down there";
        }

        public void EatLeaves()
        {
            Speak("crunching tasty leaves");
        }
    }
}
