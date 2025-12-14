using UnityEngine;

namespace Zoo
{
    class Hippo : Animal, IHerbivore
    {
        protected override string GetHelloMessage()
        {
            return "splash";
        }

        public void EatLeaves()
        {
            Speak("munch munch lovely");
        }
    }
}
