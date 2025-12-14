using System.Collections;
using UnityEngine;

namespace Zoo
{
    class Pig : Animal, IHerbivore, ICarnivore, ITrickPerformer
    {
        private Coroutine activeTrick;

        protected override string GetHelloMessage()
        {
            return "oink oink";
        }

        public void EatLeaves()
        {
            Speak("munch munch oink");
        }

        public void EatMeat()
        {
            Speak("nomnomnom oink thx");
        }

        public void PerformTrick()
        {
            Speak("watch me spin!");
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
