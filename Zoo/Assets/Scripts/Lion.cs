using UnityEngine;

namespace Zoo
{
    class Lion : Animal, ICarnivore
    {
        protected override string GetHelloMessage()
        {
            return "roooaoaaaaar";
        }

        public void EatMeat()
        {
            Speak("nomnomnom thx mate");
        }
    }
}
