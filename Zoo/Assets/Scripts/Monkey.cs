using System.Collections;
using UnityEngine;

namespace Zoo
{
    class Monkey : Animal, IHerbivore, ICarnivore, ITrickPerformer
    {
        private Coroutine activeTrick;

        protected override string GetHelloMessage()
        {
            return "ooo hello!";
        }

        public void EatLeaves()
        {
            Speak("munching fruit from the trees");
        }

        public void EatMeat()
        {
            Speak("snacking on crunchy insects");
        }

        public void PerformTrick()
        {
            Speak("check out my flips!");
            if (activeTrick != null)
            {
                StopCoroutine(activeTrick);
            }

            activeTrick = StartCoroutine(Swing());
        }

        private IEnumerator Swing()
        {
            var time = 0f;
            var duration = 1.5f;
            var startRotation = transform.localRotation;
            while (time < duration)
            {
                var t = Mathf.Sin(time * Mathf.PI * 2f) * 45f;
                transform.localRotation = Quaternion.Euler(0, 0, t);
                time += Time.deltaTime;
                yield return null;
            }

            transform.localRotation = startRotation;
            activeTrick = null;
        }
    }
}
