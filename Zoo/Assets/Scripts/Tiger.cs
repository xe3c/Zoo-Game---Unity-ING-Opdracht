using System.Collections;
using UnityEngine;

namespace Zoo
{
    class Tiger : Animal, ICarnivore, ITrickPerformer
    {
        private Coroutine activeTrick;

        protected override string GetHelloMessage()
        {
            return "rraaarww";
        }

        public void EatMeat()
        {
            Speak("nomnomnom thx wubalubadubdub");
        }

        public void PerformTrick()
        {
            Speak("grrr watch this!");
            if (activeTrick != null)
            {
                StopCoroutine(activeTrick);
            }

            activeTrick = StartCoroutine(DoTrick());
        }

        IEnumerator DoTrick()
        {
            for (int i = 0; i < 360; i++)
            {
                transform.localRotation = Quaternion.Euler(i, 0, 0);
                yield return new WaitForEndOfFrame();
            }

            transform.localRotation = Quaternion.identity;
            activeTrick = null;
        }
    }
}
