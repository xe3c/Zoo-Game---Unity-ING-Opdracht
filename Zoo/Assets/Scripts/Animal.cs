using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

namespace Zoo
{
    // Basisklasse voor alle dieren in de zoo.
    // Elk dier heeft een naam en een tekstballon om te praten.
    public abstract class Animal : MonoBehaviour
    {
        [SerializeField]
        private GameObject Balloon; // Het object dat zichtbaar wordt als het dier praat.
        [SerializeField]
        private Text text; // De tekstcomponent die het bericht toont in de ballon.
        [FormerlySerializedAs("name")]
        [SerializeField]
        private string customName; // Naam van het dier (kan in Unity ingevuld worden).

        // Haalt de naam van het dier op. Als er geen custom naam is ingevuld, gebruik de objectnaam.
        public string AnimalName => string.IsNullOrWhiteSpace(customName) ? gameObject.name : customName;

        // Laat het dier iets zeggen door de tekst en ballon aan te passen.
        protected void Speak(string message)
        {
            if (Balloon != null)
            {
                Balloon.SetActive(true);
            }

            if (text != null)
            {
                text.text = message;
            }
        }

        // Past de naam van het dier aan (gebruikt door controller).
        public void SetAnimalName(string newName)
        {
            customName = newName;
        }

        // Laat het dier hallo zeggen. De specifieke tekst wordt bepaald door het subklasse dier.
        public void SayHello()
        {
            Speak(GetHelloMessage());
        }

        // Wordt geimplementeerd door specifieke dieren om hun unieke hallo bericht te geven.
        protected abstract string GetHelloMessage();
    }

    // Interfaces definieren wat voor soort dier het is en welk gedrag het heeft.
    public interface IHerbivore
    {
        void EatLeaves();
    }

    public interface ICarnivore
    {
        void EatMeat();
    }

    public interface ITrickPerformer
    {
        void PerformTrick();
    }
}
